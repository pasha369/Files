using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework_1._5
{
    public partial class Form1 : Form
    {
        Module DrawerModule { get; set; }
        object Drawer;



        public Form1()
        {
            InitializeComponent();
        }

        public Form1(Module drawer, object targetWindow)
        {
            DrawerModule = drawer;
            Drawer = targetWindow;

            InitializeComponent();
           
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            DrawerModule.GetType("GraphDesigner.Form1").GetMethod("SetTemp").Invoke(Drawer, new object[] { Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value) });
        }
    }
}
