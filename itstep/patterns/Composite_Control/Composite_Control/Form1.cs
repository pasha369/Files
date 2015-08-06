using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Composite_Control
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            AbstractControl control = new CustomControl();

            control.source = new Form();
            control.source.Height = 400;
            AbstractControl btn = new Btn();
            btn.Add(new Txt());
            btn.Add(new Lab());
            control.Add(btn);
            control.Add(new Btn());
            control.Add(new Lab());
            control.Add(new Btn());

            control.Display();
            //Controls.Add(control.Display().source);

        }
    }
    /// <summary>
    /// Component
    /// </summary>
    abstract class AbstractControl : UserControl
    {
        public List<AbstractControl> childs;
        public Control source { set; get; }


        public abstract void Add(AbstractControl child);
        public abstract void Display();
    }

    /// <summary>
    /// Composite
    /// </summary>
    class CustomControl : AbstractControl
    {

        public CustomControl()
        {
            source = new Form();

            childs = new List<AbstractControl>();
        }
        public override void Add(AbstractControl child)
        {
            childs.Add(child);
        }

        public override void Display()
        {
            AbstractControl prev = null;

            foreach (var child in childs)
            {
                if(prev != null)
                {
                    source.Height += child.source.Height;
                    child.source.Location = new Point(prev.source.Location.X, prev.source.Location.Y + prev.source.Height);    
                }
                
                prev = child;
                source.Controls.Add(child.source);

                child.Display();

            }
           
            source.Show();
        }
    }


    /// <summary>
    /// Leaf
    /// </summary>
    class Btn : CustomControl
    {
        public Btn()
        {
            source = new Button();
            source.Text = "button";
            source.AutoSize = true;
        }
    }


    /// <summary>
    /// Leaf
    /// </summary>
    internal class Txt : CustomControl
    {

        public Txt()
        {
            source = new TextBox();
            source.Text = "TextBox";
            source.AutoSize = true;
        }
    }


    /// <summary>
    /// Leaf
    /// </summary>
    class Lab : CustomControl
    {
        public Lab()
        {
            source = new Label();
            source.Text = "label";
            source.AutoSize = true;
        }
    }
}
