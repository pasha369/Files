using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Add_Domain
{
    class Program
    {
        static AppDomain TemperatureDrawer;
        static AppDomain DataWindow;
        static Assembly TemperatureDrawerAsm;
        static Assembly DataWindowAsm;
        static Form TemperatureDrawerWindow;
        static Form DataWindowWnd;


        [STAThread]
        [LoaderOptimization(LoaderOptimization.MultiDomain)]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            TemperatureDrawer = AppDomain.CreateDomain("GraphDesigner");
            DataWindow = AppDomain.CreateDomain("homework 1.5");
            TemperatureDrawerAsm = TemperatureDrawer.Load(AssemblyName.GetAssemblyName("GraphDesigner.exe"));
            DataWindowAsm = TemperatureDrawer.Load(AssemblyName.GetAssemblyName("homework 1.5.exe"));

            TemperatureDrawerWindow = Activator.CreateInstance(TemperatureDrawerAsm.GetType("GraphDesigner.Form1")) as Form;

            DataWindowWnd = Activator.CreateInstance(
            DataWindowAsm.GetType("homework_1._5.Form1"),
            new object[]
                 {
                     TemperatureDrawerAsm.GetModule("GraphDesigner.exe"),
                     TemperatureDrawerWindow
                 }) as Form;

            (new Thread(new ThreadStart(RunSetter))).Start();
            (new Thread(new ThreadStart(RunDrawer))).Start();
        }
        static void RunDrawer()
        {
            TemperatureDrawerWindow.ShowDialog();
            Application.Exit();
        }
        static void RunSetter()
        {
            DataWindowWnd.ShowDialog();
            Application.Exit();
        }
    }
}
