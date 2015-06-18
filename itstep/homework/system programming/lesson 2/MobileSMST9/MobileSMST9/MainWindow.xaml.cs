using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
using System.Windows.Threading;

namespace MobileSMST9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isNewBtn;
        private Button curBtn;
        private int index;

        private List<string> dict;

        private Timer timer;
        public MainWindow()
        {
            InitializeComponent();

            dict = new List<string>();
        }

        private void btnClear_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdd_Click_1(object sender, RoutedEventArgs e)
        {
            dict.Add(txtField.SelectedText);
        }

        private void btnNum_Click_1(object sender, RoutedEventArgs e)
        {
            
            if(curBtn == null || curBtn != sender as Button)
            {
                txtField.CaretIndex += 1;
                txtField.SelectionStart = txtField.CaretIndex;
                txtField.Focus();

                index = 0;
                isNewBtn = true;
                curBtn = sender as Button;
                timer = new Timer(new TimerCallback(SetSymbol));
                timer.Change(3000, 3000);

                
            }
            char[] symbols = Regex.Replace(curBtn.Content.ToString(), @"\s+", "").ToCharArray();


            Thread runByDict = new Thread(new ThreadStart(RunByDict));
            runByDict.Start();

            index++;
            if(index == symbols.Length)
            {
                index = 0;
            }

            txtField.SelectedText = symbols[index].ToString();

            txtField.SelectionStart = txtField.Text.Length - 1;
            txtField.Focus();

            
        }

        private void SetSymbol(object state)
        {
            lock (this)
            {
                Application.Current.Dispatcher.BeginInvoke(
                DispatcherPriority.Background,
                new Action(() =>
                 {
                     txtField.CaretIndex += 1;
                     txtField.SelectionLength = 0;
                     txtField.SelectionStart = txtField.CaretIndex;
                 }));
                
            }

            timer.Dispose();
        }

        private void RunByDict()
        {
            string finded_word = "";
            Application.Current.Dispatcher.BeginInvoke(
                DispatcherPriority.Background,
                new Action(() =>
                               {
                                    finded_word = FindEnterWordInDict(txtField.Text.Split(' ').Last());
                                  
            if (finded_word != "")
            {
                txtField.SelectionStart = txtField.Text.Length - 1;
                txtField.Focus();
                txtField.SelectedText = FindEnterWordInDict(txtField.Text.Split(' ').Last());
                txtField.SelectionStart = txtField.Text.Length + 1 -
                                          FindEnterWordInDict(txtField.Text.Split(' ').Last()).Length;
                return;
            }
            }));
        }

        private  string FindEnterWordInDict(string inWord)
        {
            foreach (var word in dict)
            {
                if(word.Contains(inWord))
                {
                    return word;
                }
            }
            return "";
        }
    }
}
