namespace ModelTest
{
	using System;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using DomainModel.Logic;
	[TestClass]
	public class AutomaticUnload
	{
		private ExchangeManager exchangeManager;

		[TestInitialize]
		public void Init()
		{
			this.exchangeManager = new ExchangeManager("", "TestUnload.xml", "", new Logger("Log.txt", ""));
		}

		[TestMethod]
		public void UnloadForLastMonthOnDateTest()
		{
			this.exchangeManager.UnloadForLastMonthOnDate(DateTime.Now);
		}
	}
}
