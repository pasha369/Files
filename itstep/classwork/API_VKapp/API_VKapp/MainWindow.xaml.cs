using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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
using Newtonsoft.Json;
namespace API_VKapp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string acess_token;
        private string user_id;
        private RootObject root;
        public MainWindow()
        {
            InitializeComponent();
            WebBrowserWindow.Navigate(String.Format("https://oauth.vk.com/authorize?client_id={0}&" +
                                                    "scope={1}&" +
                                                    "display=popup&" +
                                                    "redirect_uri=https://oauth.vk.com/blank.html&" +
                                                    "v=5.33&" +
                                                    "response_type=token", 4935025, "friends"));
            WebBrowserWindow.LoadCompleted += WebBrowserWindowOnLoadCompleted;
        }

        private void WebBrowserWindowOnLoadCompleted(object sender, NavigationEventArgs navigationEventArgs)
        {
            Regex regex = new Regex(@"(?<name>[\w\d\x5f]+)=(?<value>[^\x26\s]+)", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            var match = regex.Match(navigationEventArgs.Uri.ToString());

            user_id = match.Groups["name"].ToString();
            acess_token = match.Groups["value"].ToString();
        }

        private void BtnQuery_OnClick(object sender, RoutedEventArgs e)
        {
            string method_name = "friends.get";
            string parameters = "v=5.33";
            var query = String.Format(
                "https://api.vk.com/method/{0}?{3}&{1}&access_token={2}&fields=nickname", method_name, parameters, acess_token, user_id);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(query);
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            StreamReader myStream = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string s = myStream.ReadToEnd();
            txtOut.Text = s;
            root = JsonConvert.DeserializeObject<RootObject>(txtOut.Text);
            if (root == null)
            {
                Debug.WriteLine(s.Length);
            }

        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            foreach (var item in root.response.items)
            {
                txtNames.Text += item.first_name + ' ' + item.last_name + '\n';
            }
        }
    }
}
