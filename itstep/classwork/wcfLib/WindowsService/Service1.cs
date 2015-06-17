using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService
{
    public partial class Service1 : ServiceBase
    {
        private ServiceHost sh;
        public Service1()
        {
            InitializeComponent();

            sh = new ServiceHost(typeof(Service1));
           

        }

        protected override void OnStart(string[] args)
        {
            sh.Open();
 
        }

        protected override void OnStop()
        {
            sh.Close();
        }
    }
}
