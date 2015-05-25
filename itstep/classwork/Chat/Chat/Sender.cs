using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    class Sender
    {

        private IPAddress ipAddress;
        private IPEndPoint remoteEP;
        private byte[] byteData;
        private int offset;
        private Socket client;

        public Sender(string ip, int port)
        {
            ipAddress = IPAddress.Parse(ip);
            remoteEP = new IPEndPoint(ipAddress, port);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

           
        }

        private void OnConnect(IAsyncResult ar)
        {
            try
            {
                Socket client = (Socket)ar.AsyncState;
                client.EndConnect(ar);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public void Send( string content)
        {
            client.BeginConnect(remoteEP, new AsyncCallback(OnConnect), client);
            byteData = Encoding.ASCII.GetBytes(content);
            offset = 0;

            client.BeginSend(byteData, offset, Math.Min(byteData.Length, 1024), 0,
                new AsyncCallback(OnSend), client);
        }

        private void OnSend(IAsyncResult ar)
        {
            try
            {
                Socket handler = (Socket)ar.AsyncState;
                int byteSend = handler.EndSend(ar);
                offset += byteSend;

                if (offset < byteData.Length)
                    handler.BeginSend(byteData, offset, Math.Min(byteData.Length - offset, 1024), 0, new AsyncCallback(OnSend), handler);
                else
                {
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();   
                }
                
                

            }
            catch (Exception)
            {

                throw;
            }
        }



    }
}
