using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace homework_virus
{
    class Program
    {
        static void Main(string[] args)
        {
            string user = Registry.CurrentUser.Name,
                skey = "GetSetValue",
                skeyName = user + "//" + skey;
            RegistryKey myKey = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop\", true);
            myKey.SetValue("Wallpaper", @"C:\Users\pasha\Downloads\cool-cat-hd-wallpaper.jpg");

            RegistryKey show_task = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects\TaskbarAnimations", true);
            show_task.SetValue("Settings", 1);
            show_task.SetValue("DisableTaskMgr", 0);

            ExitWindowsEx(0, 0);

        }
        [DllImport("user32")]
        public static extern bool ExitWindowsEx(uint Flag, uint Reason);
    }
}
