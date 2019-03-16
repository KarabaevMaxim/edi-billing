namespace FTPTransporter
{
	using System.Collections.Generic;
    using System.ComponentModel;
    using System.ServiceProcess;
    using System.Configuration.Install;

    [RunInstaller(true)]
    public partial class Installer1 : Installer
    {
        //ServiceInstaller serviceInstaller;
        //ServiceProcessInstaller processInstaller;

		private readonly List<ServiceInstaller> serviceInstallers = new List<ServiceInstaller>();
		private readonly List<ServiceProcessInstaller> processInstallers = new List<ServiceProcessInstaller>();

		public Installer1()
        {
            InitializeComponent();
            //serviceInstaller = new ServiceInstaller();
            //processInstaller = new ServiceProcessInstaller
            //{
            //    Account = ServiceAccount.User
            //};
            //serviceInstaller.StartType = ServiceStartMode.Automatic;
            //serviceInstaller.ServiceName = "EDITransport";
            //Installers.Add(processInstaller);
            //Installers.Add(serviceInstaller);

			serviceInstallers.Add(new ServiceInstaller
			{
				StartType = ServiceStartMode.Automatic,
				ServiceName = "EDITransport"
			});

			processInstallers.Add(new ServiceProcessInstaller
			{
				Account = ServiceAccount.User
			});

			serviceInstallers.Add(new ServiceInstaller
			{
				StartType = ServiceStartMode.Automatic,
				ServiceName = "EdiHelperExchangeService"
			});

			processInstallers.Add(new ServiceProcessInstaller
			{
				Account = ServiceAccount.User
			});

			foreach (var item in serviceInstallers)
				base.Installers.Add(item);

			foreach (var item in processInstallers)
				base.Installers.Add(item);
		}
    }
}
