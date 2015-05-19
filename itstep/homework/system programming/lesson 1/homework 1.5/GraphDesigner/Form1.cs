using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GraphDesigner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void SetTemp(int date, int temperature)
        {
            chart1.Series["graph"].Points.AddXY
                                (date, temperature);

            chart1.Series["graph"].ChartType =
                                SeriesChartType.FastLine;
        }
    }
}
