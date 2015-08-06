using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype_Image
{
    public partial class Form1 : Form
    {
        private Timer timer;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            ImageManager imageManager = new ImageManager(@"C:\tetris\");

            timer = new Timer()
                        {
                            Interval = (int)nUpDownPeriod.Value * 1000
                        };

            nUpDownPeriod.Enabled = false;

            int index = 0;
            int figNumber = 6;
            timer.Tick += delegate
                              {
                                  index++;
                                  if (rbtnShallow.Checked)
                                  {
                                      picBoxDisplay.Image = (imageManager[index].Clone() as ImagePrototype).Source;
                                  }
                                  else if (rbtnDeep.Checked)
                                  {
                                      picBoxDisplay.Image = (imageManager[index].DeepCopy() as ImagePrototype).Source;
                                  }

                                  if (index == figNumber)
                                  {
                                      index = 0;
                                  }
                              };
            timer.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            nUpDownPeriod.Enabled = true;

            timer.Stop();
        }
    }
}
