using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirusServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            Thread udpThread  = new Thread(new ThreadStart(serverThread));
            udpThread.Start();
        }

        public void serverThread()
        {
             while (true)
                    {
                        using (UdpClient udpClient = new UdpClient(9050))
                        {
                            try
                            {

                                IPEndPoint remoteIPEndPoint = null;
                                Byte[] receiveBytes = udpClient.Receive(ref remoteIPEndPoint);
                                string returnData = Encoding.ASCII.GetString(receiveBytes);
                                lock (this)
                                {
                                    Invoke((MethodInvoker)delegate
                                    {
                                        txtReceiveData.AppendText(returnData);
                                    });
                                }




                            }
                            catch (Exception ex)
                            {
                                 throw;
                            }
                        }
            }
        }
    }
}
