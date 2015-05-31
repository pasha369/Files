using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

namespace Mail
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

        private void BtnSend_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var msg = new MailMessage("zhmakp@gmail.com", "zhmakp@gmail.com", null, txtMsg.Text);
                var smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.Credentials = new NetworkCredential("zhmakp@gmail.com", "15pashuk");
                smtpClient.EnableSsl = true;
                smtpClient.Timeout = 10000;
                smtpClient.Send(msg);
            }
            catch (Exception)
            {
                
                throw;
            }

        }
    }
}
