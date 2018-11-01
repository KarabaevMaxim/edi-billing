﻿namespace DomainModel.Logic
{
    using System;
    using System.Xml;
    using System.Collections.Generic;
    using System.Linq;
    using ArxOne.Ftp;
    using System.Net;
    using System.IO;
    using Model;
    using XML;
    using Repository;

    public class ManagerFtp
    {
        private readonly FtpPath FtpPath;
        private readonly bool isPassive;
        private readonly Logger logger;
        private readonly WBService wBService;
        private readonly int timeoutSec;
        private readonly WayBillRepository wayBillRepository;

        public ManagerFtp(string ftpUri, bool isPassive, int timeoutSec, Logger logger)
        {
            this.FTPUri = new Uri(ftpUri);
            this.FtpPath = new FtpPath(SettingsContainer.GetSettings().FtpFolder);
            this.isPassive = isPassive;
            this.logger = logger;
            this.wBService = new WBService(logger);
            this.timeoutSec = timeoutSec;
            this.wayBillRepository = new WayBillRepository();
        }

        public void DownloadFiles(TradeObject tradeObject)
        {
            NetworkCredential networkCredential = new NetworkCredential(tradeObject.FtpLogin, tradeObject.FtpPassword);
            FtpClientParameters parametres = new FtpClientParameters();
            parametres.ConnectTimeout = new TimeSpan(0, 0, timeoutSec);
            parametres.ReadWriteTimeout = new TimeSpan(0, 0, timeoutSec);
            parametres.Passive = this.isPassive;

            using (var ftpClient = new FtpClient(this.FTPUri, networkCredential, parametres))
            {
                var files = ftpClient.ListEntries(FtpPath).Where(en => en.Type == FtpEntryType.File);
                this.logger.WriteLog("Document files count in directory: " + ftpClient.ListEntries(FtpPath).Count().ToString());
                foreach (var item in files)
                {
                    using (var stream = ftpClient.Retr(item.Path))
                    {
                        List<byte> byteList = new List<byte>();
                        int curByte;

                        while ((curByte = stream.ReadByte()) != -1)
                        {
                            byteList.Add((byte)curByte);
                        }

                        string newFileName = string.Empty;

                        try
                        {
                            this.logger.WriteLog(string.Format("{0} {1}", "Parsing waybill file", item.Name));
                            XMLConverter converter = new XMLConverter(byteList, this.logger);
                            

                            if (!this.wBService.AddRecord(converter.GetWaybill()))
                            {
                                this.logger.WriteLog(string.Format("{0}: {1}", "Waybill or register writing error. File", item.Name), LogTypes.ERROR);
                            }

                            Waybill waybill = wBService.GetLastWayBill();
                            newFileName = string.Format("{0}_{1}_{2}_{3}.xml", "DESADV", waybill.Number, waybill.DocumentDate.ToString("dd-MM-yyyy"), waybill.GetHashCode());
                        }
                        catch (XmlException ex)
                        {
                            this.logger.WriteLog(string.Format("{0}. File: {1}. {2}: {3}. {4}", "Waybill file parsing error", item.Name, ex.Source, ex.Message, ex.StackTrace), LogTypes.ERROR);
                        }
                        catch (Exception ex)
                        {
                            this.logger.WriteLog(string.Format("{0}. File: {1}. {2}: {3}. {4}", "Error adding waybill to db", item.Name, ex.Source, ex.Message, ex.StackTrace), LogTypes.ERROR);
                        }
                        try
                        {
                            File.WriteAllBytes(tradeObject.LocalFolder + "\\" + newFileName, byteList.ToArray());
                            this.logger.WriteLog("Saved waybill file " + newFileName, LogTypes.INFO);
                        }
                        catch (IOException ex)
                        {
                            this.logger.WriteLog(string.Format("{0}: {1}: {2}. {3}", "Error to save waybill file " + item.Name, ex.Source, ex.Message, ex.StackTrace), LogTypes.ERROR);
                        }

                        if (ftpClient.Dele(item.Path))
                        {
                            this.logger.WriteLog("File " + item.Path + " was deleted from FTP", LogTypes.INFO);
                        }
                        else
                        {
                            this.logger.WriteLog("File " + item.Path + " not deleted from FTP", LogTypes.WARNING);
                        }
                    }
                }
            }
        }

        public Uri FTPUri { get; private set; }
    }
}
