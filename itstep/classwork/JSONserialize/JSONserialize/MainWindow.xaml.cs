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
using Newtonsoft.Json;
namespace JSONserialize
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private User user;
        private string json_temp;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnSerialize_OnClick(object sender, RoutedEventArgs e)
        {

            txtOut.Text = JsonConvert.SerializeObject(user);
            json_temp = JsonConvert.SerializeObject(user);
        }

        private void BtnSave_OnClick(object sender, RoutedEventArgs e)
        {
            user = new User(txtName.Text, txtPassword.Text, 20);
        }

        private void BtnDeserialize_OnClick(object sender, RoutedEventArgs e)
        {
           
            DubUser user = JsonConvert.DeserializeObject<DubUser>(json_temp);
            txtOut.Text = "name: " + user._name + " password:" + user._password;
        }
    }
}
