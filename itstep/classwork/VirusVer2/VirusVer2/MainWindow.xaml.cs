using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace VirusVer2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Socket socket;
        private IPEndPoint ep;
        public MainWindow()
        {
            InitializeComponent();
            
            UdpClient udpClient = new UdpClient();
            udpClient.Connect(IPAddress.Broadcast, 9050);
            Byte[] senddata = Encoding.ASCII.GetBytes("Hello World");
            udpClient.Send(senddata, senddata.Length);
            
            

        }

        public byte[] buffer { get; set; }
    }
}
