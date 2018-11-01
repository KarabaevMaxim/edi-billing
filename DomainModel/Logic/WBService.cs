namespace DomainModel.Logic
{
    using System;
    using Model;
    using Repository;
    using System.Linq;
    using System.Collections.Generic;

    /// <summary>
    /// Класс сервиса обработки накладных.
    /// </summary>
    public class WBService
    {
        public WBService(Logger logger)
        {
            this.AccumRegisterRepository = new AccumRegisterRepository();
            this.WayBillRepository = new WayBillRepository();
            this.SupplierRepository = new SupplierRepository();
            this.Logger = logger;
        }

        /// <summary>
        /// Добавить в базу новую накладную и запись в регистр накопления.
        /// </summary>
        /// <param name="wb">Накладная.</param>
        /// <returns>true, если добавление накладной и добавление записи в регистр накопления произошла успешно, иначе false.</returns>
        public bool AddRecord(Waybill wb)
        {
            if(wb == null)
            {
                return false;
            }

            
            bool isRoaming = false;

            try
            {
                isRoaming = this.SupplierRepository.GetEntity(wb.SupplierID).IsRoaming;
                wb.IsRoaming = isRoaming;
            }
            catch(NullReferenceException ex)
            {
                this.Logger.WriteLog(string.Format("{0}: {1}: {2}. {3}", "Supplier with ID " + wb.SupplierID + " not found", ex.Source, ex.Message, ex.StackTrace), LogTypes.ERROR);
            }
            bool res1 = this.WayBillRepository.AddEntity(wb);
            bool res2 = this.AccumRegisterRepository.AddEntity(wb.ClientID, wb.ID, DateTime.Now, isRoaming);
            return res1 && res2;
        }

        /// <summary>
        /// Возвращает последнюю(по дате) загрузки накладную.
        /// </summary>
        /// <returns></returns>
        public Waybill GetLastWayBill()
        {
            List<Waybill> waybills = this.WayBillRepository.GetAllEntities();
            DateTime lastDate = waybills.Max(wb => wb.DownloadDate);
            Waybill waybill = waybills.Where(wb => wb.DownloadDate == lastDate).FirstOrDefault();
            return waybill;
        }

        public bool RemoveRecord()
        {
            throw new NotImplementedException();
        }

        private SupplierRepository SupplierRepository { get; set; }
        private AccumRegisterRepository AccumRegisterRepository { get; set; }
        private WayBillRepository WayBillRepository { get; set; }
        private Logger Logger { get; set; }
    }

    
}
