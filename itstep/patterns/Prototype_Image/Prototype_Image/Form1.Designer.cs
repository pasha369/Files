namespace Prototype_Image
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.picBoxDisplay = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnDeep = new System.Windows.Forms.RadioButton();
            this.rbtnShallow = new System.Windows.Forms.RadioButton();
            this.nUpDownPeriod = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxDisplay)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDownPeriod)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.picBoxDisplay, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(406, 340);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // picBoxDisplay
            // 
            this.picBoxDisplay.Location = new System.Drawing.Point(3, 3);
            this.picBoxDisplay.Name = "picBoxDisplay";
            this.picBoxDisplay.Size = new System.Drawing.Size(400, 283);
            this.picBoxDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picBoxDisplay.TabIndex = 0;
            this.picBoxDisplay.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnStop);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.nUpDownPeriod);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 292);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 45);
            this.panel1.TabIndex = 1;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(179, 16);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(59, 23);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(114, 16);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(59, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Period";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnDeep);
            this.groupBox1.Controls.Add(this.rbtnShallow);
            this.groupBox1.Location = new System.Drawing.Point(243, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(154, 42);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Copy type";
            // 
            // rbtnDeep
            // 
            this.rbtnDeep.AutoSize = true;
            this.rbtnDeep.Location = new System.Drawing.Point(87, 16);
            this.rbtnDeep.Name = "rbtnDeep";
            this.rbtnDeep.Size = new System.Drawing.Size(51, 17);
            this.rbtnDeep.TabIndex = 0;
            this.rbtnDeep.TabStop = true;
            this.rbtnDeep.Text = "Deep";
            this.rbtnDeep.UseVisualStyleBackColor = true;
            // 
            // rbtnShallow
            // 
            this.rbtnShallow.AutoSize = true;
            this.rbtnShallow.Checked = true;
            this.rbtnShallow.Location = new System.Drawing.Point(19, 16);
            this.rbtnShallow.Name = "rbtnShallow";
            this.rbtnShallow.Size = new System.Drawing.Size(62, 17);
            this.rbtnShallow.TabIndex = 0;
            this.rbtnShallow.TabStop = true;
            this.rbtnShallow.Text = "Shallow";
            this.rbtnShallow.UseVisualStyleBackColor = true;
            // 
            // nUpDownPeriod
            // 
            this.nUpDownPeriod.Location = new System.Drawing.Point(52, 16);
            this.nUpDownPeriod.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUpDownPeriod.Name = "nUpDownPeriod";
            this.nUpDownPeriod.Size = new System.Drawing.Size(47, 20);
            this.nUpDownPeriod.TabIndex = 0;
            this.nUpDownPeriod.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 340);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxDisplay)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDownPeriod)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox picBoxDisplay;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nUpDownPeriod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.RadioButton rbtnDeep;
        private System.Windows.Forms.RadioButton rbtnShallow;
        private System.Windows.Forms.Button btnStop;
    }
}

