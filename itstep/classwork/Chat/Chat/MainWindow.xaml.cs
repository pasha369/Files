using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
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

namespace Chat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private Receiver server;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnCreateServer_OnClick(object sender, RoutedEventArgs e)
        {
            server = new Receiver(txtIpServer.Text, Convert.ToInt32(txtPortServer.Text));
            server.onReseive += ServerOnOnReseive;
            server.BeginListen();
        }

        private void BtnCreateClient_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnSend_OnClick(object sender, RoutedEventArgs e)
        {
            Sender client = new Sender(txtIpClient.Text, Convert.ToInt32(txtPortClient.Text));
            
            client.Send(txtMsg.Text);
        }

        private void ServerOnOnReseive(string msg)
        {
            txtField.Dispatcher.BeginInvoke(new Action<string>((msg_add) =>
            {
                txtField.AppendText(msg + '\n');
            }), new object[] {msg});
        }
    }
}
