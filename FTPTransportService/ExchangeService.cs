namespace FTPTransporter
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Diagnostics;
	using System.Linq;
	using System.ServiceProcess;
	using System.Text;
	using System.Threading.Tasks;
	using System.Timers;
	using System.Reflection;
	using DomainModel.Logic;
	using DomainModel.Model;
	using DomainModel.Repository;
	using System.IO;

	partial class ExchangeService : ServiceBase
	{
		private readonly ExchangeManager exchangeManager;
		private readonly Settings settings;
		private readonly Logger logger;
		private readonly Timer timer;
		private DateTime nextExchangeDate;

		public ExchangeService()
		{
			InitializeComponent();
			Environment.CurrentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

			try
			{
				this.settings = SettingsContainer.GetSettings();
			}
			catch (Exception ex)
			{
				EventLog.Source = "EdiHelperExchangeService";
				EventLog.WriteEntry(string.Format("{0}: {1}. {2}", ex.StackTrace, ex.Message, "Error to initialization settings from database."));
			}

			this.CanStop = true;
			this.CanPauseAndContinue = true;
			this.AutoLog = true;
			this.ServiceName = "EdiHelperExchangeService";
			this.EventLog.Source = this.ServiceName;
			this.logger = new Logger(string.Format("{0}.{1}", this.ServiceName, "log"), this.ServiceName);
			this.exchangeManager = new ExchangeManager(this.settings.DownloadExchangeFileName, this.settings.UploadExchangeFileName, this.settings.ExchangeFolder, this.logger);
			this.timer = new Timer();
		}

		protected override void OnStart(string[] args)
		{
			StringBuilder log = new StringBuilder();
			this.timer.Enabled = true;
			this.timer.Interval = 86400 * 1000; // раз в сутки
			this.timer.Elapsed += new ElapsedEventHandler(Tick);
			this.timer.AutoReset = true;
			this.timer.Start();
			this.nextExchangeDate = DateTime.Now;
			log.AppendFormat("Служба обмена запущена. День месяца выгрузки: {0}", this.settings.DayOfMonthToUnload);
			this.logger.WriteLog(log.ToString());
			this.CheckAndUnload();
		}

		protected override void OnStop()
		{
			this.logger.WriteLog("Служба обмена остановлена");
		}

		private void Tick(object sender, ElapsedEventArgs e)
		{
			this.CheckAndUnload();
		}

		private void CheckAndUnload()
		{
			this.logger.WriteLog("Проверка необходимости выгрузки");

			if (DateTime.Now >= this.nextExchangeDate)
			{
				try
				{
					this.logger.WriteLog("Начало выгрузки");
					this.exchangeManager.UnloadForLastMonthOnDate(this.nextExchangeDate);
					this.nextExchangeDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, this.settings.DayOfMonthToUnload);
					this.logger.WriteLog("Выгрузка закончена");
				}
				catch (Exception ex)
				{
					this.logger.WriteLog(string.Format("{0}, {1}: {2}. Ошибка при выгрузке", ex.Source, ex.StackTrace, ex.Message), LogTypes.ERROR);
				}

			}

			this.logger.WriteLog("Проверка завершена");
		}
	}
}
