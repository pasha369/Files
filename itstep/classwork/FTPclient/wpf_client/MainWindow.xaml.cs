using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

namespace wpf_client
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

        private void BtnLoad_OnClick(object sender, RoutedEventArgs e)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(txtPath.Text);
            request.Method = WebRequestMethods.Ftp.ListDirectory;

            request.Credentials = new NetworkCredential(txtName.Text, txtPasswd.Text);

            FtpWebResponse response = (FtpWebResponse) request.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);

            tvFiles.Items.Clear();
            string[] list = reader.ReadToEnd().Split('\n');
            foreach (var file in list)
            {
                tvFiles.Items.Add(file);
            }

            //txtFiles.Text = reader.ReadToEnd();

            reader.Close();
            response.Close();

        }

        private void TvFiles_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            var path = tvFiles.SelectedItem.ToString().Trim('\r');
            txtPath.Text = txtPath.Text.Trim(' ') + path;
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(txtPath.Text);
            request.Method = WebRequestMethods.Ftp.ListDirectory;

            request.Credentials = new NetworkCredential(txtName.Text, txtPasswd.Text);

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            tvFiles.Items.Clear();
            string[] list = reader.ReadToEnd().Split('\n');
            foreach (var file in list)
            {
                tvFiles.Items.Add(file);
            }

            reader.Close();
            response.Close();
        }
    }
}
