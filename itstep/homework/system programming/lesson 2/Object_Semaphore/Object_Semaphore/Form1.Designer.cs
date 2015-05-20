namespace Object_Semaphore
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
            this.listViewWork = new System.Windows.Forms.ListView();
            this.listViewWait = new System.Windows.Forms.ListView();
            this.listViewCreate = new System.Windows.Forms.ListView();
            this.numSemaphore = new System.Windows.Forms.NumericUpDown();
            this.btnCreate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numSemaphore)).BeginInit();
            this.SuspendLayout();
            // 
            // listViewWork
            // 
            this.listViewWork.Location = new System.Drawing.Point(44, 37);
            this.listViewWork.Name = "listViewWork";
            this.listViewWork.Size = new System.Drawing.Size(96, 126);
            this.listViewWork.TabIndex = 0;
            this.listViewWork.UseCompatibleStateImageBehavior = false;
            this.listViewWork.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // listViewWait
            // 
            this.listViewWait.Location = new System.Drawing.Point(227, 37);
            this.listViewWait.Name = "listViewWait";
            this.listViewWait.Size = new System.Drawing.Size(92, 126);
            this.listViewWait.TabIndex = 0;
            this.listViewWait.UseCompatibleStateImageBehavior = false;
            this.listViewWait.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // listViewCreate
            // 
            this.listViewCreate.Location = new System.Drawing.Point(388, 37);
            this.listViewCreate.Name = "listViewCreate";
            this.listViewCreate.Size = new System.Drawing.Size(93, 126);
            this.listViewCreate.TabIndex = 0;
            this.listViewCreate.UseCompatibleStateImageBehavior = false;
            this.listViewCreate.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listViewCreate.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewCreate_MouseDoubleClick);
            // 
            // numSemaphore
            // 
            this.numSemaphore.Location = new System.Drawing.Point(221, 190);
            this.numSemaphore.Name = "numSemaphore";
            this.numSemaphore.Size = new System.Drawing.Size(120, 20);
            this.numSemaphore.TabIndex = 1;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(388, 187);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(102, 23);
            this.btnCreate.TabIndex = 2;
            this.btnCreate.Text = "Создать поток";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Работающие потоки";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(224, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ожидающие потоки";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(385, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "label1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(385, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Созданые потоки";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Количество мест в семафоре";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 225);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.numSemaphore);
            this.Controls.Add(this.listViewCreate);
            this.Controls.Add(this.listViewWait);
            this.Controls.Add(this.listViewWork);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numSemaphore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewWork;
        private System.Windows.Forms.ListView listViewWait;
        private System.Windows.Forms.ListView listViewCreate;
        private System.Windows.Forms.NumericUpDown numSemaphore;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

