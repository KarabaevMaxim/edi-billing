﻿namespace FTPTransporter
{
    using System;
    using System.ServiceProcess;
    using System.Text;
    using System.Timers;
    using DomainModel.Logic;
    using DomainModel.Model;
    using DomainModel.Repository;
    using System.IO;
    using System.Diagnostics;
    using System.Reflection;

    /// <summary>
    /// Класс службы транспорта.
    /// </summary>
    public partial class FTPTransporter : ServiceBase
    {
        private readonly ManagerFtp FtpManager;
        private readonly Logger Logger;
        private readonly Timer Timer;
        private readonly Settings Settings;
        private readonly WayBillRepository WayBillRepository;
        private readonly TradeObjectRepository TradeObjectRepository;

        public FTPTransporter()
        {
            InitializeComponent();
            
            Environment.CurrentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            try
            {
                this.Settings = SettingsContainer.GetSettings();
            }
            catch(Exception ex)
            {
                EventLog.Source = "FtpTransporter";
                EventLog.WriteEntry(string.Format("{0}: {1}. {2}", ex.StackTrace, ex.Message, "Ошибка загрузки настроек из базы"));
            }

            this.CanStop = true;
            this.CanPauseAndContinue = true;
            this.AutoLog = true;
            this.ServiceName = this.Settings.ServiceName;
            EventLog.Source = this.ServiceName;
            this.Logger = new Logger(string.Format("{0}.{1}", this.ServiceName, "log"), this.ServiceName);
            this.Timer = new Timer();
            this.FtpManager = new ManagerFtp(this.Settings.FtpUri, Convert.ToBoolean(this.Settings.FtpIsPassive), 
                                            this.Settings.FtpTimeoutSec, this.Logger);
            this.WayBillRepository = new WayBillRepository();
            this.TradeObjectRepository = new TradeObjectRepository();

		}

        /// <summary>
        /// Событие запуска службы.
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            StringBuilder log = new StringBuilder();
            log.AppendFormat("Служба запущена. ФТП URI: {0} Интервал проверки: {1} секунд. Пассивный режим ФТП: {2}. Таймаут: {3} секунд",
                this.Settings.FtpUri, this.Settings.FtpDownloadInttervalSec, this.Settings.FtpIsPassive, this.Settings.FtpTimeoutSec);
            this.Timer.Enabled = true;
            this.Timer.Interval = this.Settings.FtpDownloadInttervalSec * 1000;
            this.Timer.Elapsed += new ElapsedEventHandler(Tick);
            this.Timer.AutoReset = true;
            this.Timer.Start();
            this.Logger.WriteLog(log.ToString());
        }

        /// <summary>
        /// Событие остановки службы.
        /// </summary>
        protected override void OnStop()
        {
            this.Logger.WriteLog("Служба остановлена");

        }

        /// <summary>
        /// Событие тика таймера.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tick(object sender, ElapsedEventArgs e)
        {
            this.Logger.WriteLog("Начало проверки накладных на ФТП сервере");

            foreach (var item in this.TradeObjectRepository.GetAllEntities())
            {
                this.Logger.WriteLog("Проверка накладных объекта с ID:" + item.ID + " " + item.Name);

				if(!item.IsCheck.HasValue || !item.IsCheck.Value)
				{
					this.Logger.WriteLog("Пропуск объекта с ID:" + item.ID + " " + item.Name);
					continue;
				}

                try
                {
                    this.FtpManager.DownloadFiles(item);
                }
                catch (Exception ex)
                {
                    this.Logger.WriteLog(string.Format("{0}, {1}: {2}. Ошибка загрузки накладных", ex.Source, ex.StackTrace, ex.Message), LogTypes.ERROR);
                }
            }

            this.Logger.WriteLog("Окончание проверки накладных на ФТП сервере");
		}
    }
}
