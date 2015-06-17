using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PortScaner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnScaner_Click_1(object sender, RoutedEventArgs e)
        {
            
            int start = 1000;
            int end = 65000;
            /*
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] tcpEndPoints = properties.GetActiveTcpListeners();

            List<int> usedPorts = tcpEndPoints.Select(p => p.Port).ToList<int>();
            for(int i = start; i < end; i ++)
            {
                if(!usedPorts.Contains(i))
                {
                    txtFreePorts.AppendText(i.ToString() + '\n');
                }
            }*/

            for (int i = 0; i < end; i++)
            {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    socket.Bind(new IPEndPoint(IPAddress.Parse("192.168.1.24"), i));
                    txtFreePorts.AppendText(i.ToString()+'\n');

                }catch(Exception  exception)
                {
                    Debug.WriteLine(exception.Message);
                }
            }

        }
    }
}
