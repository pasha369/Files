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

        private DataSet ds;

        public Form1()
        {
            InitializeComponent();
        }

        public Form1(Module drawer, object targetWindow)
        {
            DrawerModule = drawer;
            Drawer = targetWindow;

            InitializeComponent();
            ds = new DataSet();

            DataTable table = new DataTable();
            table.Columns.Add("date");
            table.Columns.Add("temperature");
            table.Rows.Add(1, 1);
            table.Rows.Add(12, 2);
            table.Rows.Add(1, 1);
            table.Rows.Add(12, 2);
            table.Rows.Add(1, 1);
            table.Rows.Add(12, 2);

            ds.Tables.Add(table);
            DrawerModule.GetType("GraphDesigner.Form1").GetMethod("SetTemp").Invoke(Drawer, new object[] { 1, 2 });
            DrawerModule.GetType("GraphDesigner.Form1").GetMethod("SetTemp").Invoke(Drawer, new object[] { 10, 22 });
        }
    }
}
