using System;
using System.Collections.Generic;
using System.Linq;
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
using OpenPop.Mime;
using OpenPop.Pop3;

namespace OPENPOPexample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var msg = FetchAllMessages("pop.gmail.com", 995, true, "zhmakp@gmail.com", "15pashuk");
            string result = System.Text.Encoding.Default.GetString( msg[0].RawMessage.);

            wbBrowser.NavigateToString(result);
        }

        public static List<Message> FetchAllMessages(string hostname, int port, bool useSsl, string username, string password)
        {
            using (Pop3Client client = new Pop3Client())
            {
                // Connect to the server
                client.Connect(hostname, port, useSsl);

                // Authenticate ourselves towards the server
                client.Authenticate(username, password);

                // Get the number of messages in the inbox
                int messageCount = client.GetMessageCount();

                // We want to download all messages
                List<Message> allMessages = new List<Message>(messageCount);

                for (int i = 50; i > 0; i--)
                {
                    allMessages.Add(client.GetMessage(i));
                }

                // return the fetched messages
                return allMessages;
            }
        }
    }
}
