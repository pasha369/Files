using System;
using System.Collections.Generic;
using System.Linq;
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
                index = 0;
                isNewBtn = true;
                curBtn = sender as Button;
            }
            
            char[] symbols = Regex.Replace(curBtn.Content.ToString(), @"\s+", "").ToCharArray();

            if(index == symbols.Length)
            {
                index = 0;
            }
            if (FindEnterWordInDict(txtField.Text.Split(' ').Last()) != "")
            {
                txtField.AppendText(FindEnterWordInDict(txtField.Text.Split(' ').Last()));
                return;
            }
            txtField.AppendText(symbols[index].ToString());

            index++;
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
