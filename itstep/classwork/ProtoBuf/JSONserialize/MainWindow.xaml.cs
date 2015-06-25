using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using ProtoBuf;
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

            TestProtoBuf(user, "Test");
        }

        private void BtnSave_OnClick(object sender, RoutedEventArgs e)
        {
            user = new User(txtName.Text, txtPassword.Text, 20);
        }

        private void BtnDeserialize_OnClick(object sender, RoutedEventArgs e)
        {
           
            //DubUser user = Serializer.Deserialize<DubUser>(json_temp);
        }

        private static void TestProtoBuf(User user, string fileName)
        {
            var stopwatch = new Stopwatch();
            using (var file = File.Create(fileName))
            {
                stopwatch.Start();

     
                    file.Position = 0;
                    Serializer.Serialize(file, user);
                    file.Position = 0;
                    var restoredTasks = Serializer.Deserialize<User>(file);
                

                stopwatch.Stop();

                Debug.WriteLine(" iteration in {0} ms", stopwatch.ElapsedMilliseconds);
            }
        }
    }
}
