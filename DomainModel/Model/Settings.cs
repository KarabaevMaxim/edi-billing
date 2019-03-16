namespace DomainModel.Model
{
	using System;

    public class Settings : IEntity
    {
        /// <summary>
        /// Идентификатор записи.
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// URI ФТП сервера.
        /// </summary>
        public string FtpUri { get; set; }
        /// <summary>
        /// Папка для загрузки на ФТП.
        /// </summary>
        public string FtpFolder { get; set; }
        /// <summary>
        /// Интервал опроса в секундах.
        /// </summary>
        public int FtpDownloadInttervalSec { get; set; }
        /// <summary>
        /// Режим ФТП.
        /// </summary>
        public int FtpIsPassive { get; set; }
        /// <summary>
        /// Название службы.
        /// </summary>
        public string ServiceName { get; set; }
        /// <summary>
        /// Таймаут ФТП в секундах.
        /// </summary>
        public int FtpTimeoutSec { get; set; }
        /// <summary>
        /// Папка для обмена с внешней системой.
        /// </summary>
        public string ExchangeFolder { get; set; }
        /// <summary>
        /// Локальное имя файла загрузки.
        /// </summary>
        public string DownloadExchangeFileName { get; set; }
        /// <summary>
        /// Локальное имя файла выгрузки.
        /// </summary>
        public string UploadExchangeFileName { get; set; }

		public int DayOfMonthToUnload { get; set; }

        public bool LikeAs(IEntity other)
        {
            throw new System.NotImplementedException();
        }

        public void Reinitialization(IEntity other)
        {
            if (!(other is Settings newSettings))
            {
                return;
            }

			foreach (var item in other.GetType().GetProperties())
			{
				if(item.Name != "ID")
					item.SetValue(this, item.GetValue(newSettings));
			}
        }
    }
}
