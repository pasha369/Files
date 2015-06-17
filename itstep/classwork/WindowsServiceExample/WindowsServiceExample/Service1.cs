using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceExample
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            this.MyLog("Servise started");
        }

        private void MyLog(string p)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("log.txt", true))
                {
                    string msg = "\t\t";
                    msg += p;
                    sw.WriteLine(msg);
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        protected override void OnStop()
        {
            this.MyLog("Servise stoped");
        }
    }
}
