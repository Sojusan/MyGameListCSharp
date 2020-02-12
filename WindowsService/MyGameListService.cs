using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using WcfServiceLibrary;
using System.Configuration;
using System.Configuration.Install;

namespace WindowsService
{
    public partial class MyGameListService : ServiceBase
    {
        public const string NazwaUslugi = "MyGameList";
        public ServiceHost serviceHost = null;
        public MyGameListService()
        {
            this.ServiceName = NazwaUslugi;
        }

        protected override void OnStart(string[] args)
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
            }
            serviceHost = new ServiceHost(typeof(Service1));
            serviceHost.Open();
        }

        protected override void OnStop()
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
                serviceHost = null;
            }
        }
    }
}
