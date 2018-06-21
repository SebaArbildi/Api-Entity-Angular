namespace DocSystWindowsApp
{
    partial class ReportForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(515, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 51);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reportes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(103, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Usuarios";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Location = new System.Drawing.Point(66, 213);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(200, 204);
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(305, 213);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 34);
            this.button1.TabIndex = 3;
            this.button1.Text = "Seleccionar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(580, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha Desde";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(580, 281);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Fecha Hasta";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(749, 213);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 31);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(749, 281);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 31);
            this.dateTimePicker2.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(491, 422);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(223, 36);
            this.button2.TabIndex = 9;
            this.button2.Text = "Generar reporte";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 25;
            this.listBox2.Location = new System.Drawing.Point(375, 565);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(148, 229);
            this.listBox2.TabIndex = 10;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(749, 343);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(200, 33);
            this.comboBox1.TabIndex = 11;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(637, 351);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 25);
            this.label5.TabIndex = 12;
            this.label5.Text = "Accion";
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 25;
            this.listBox3.Location = new System.Drawing.Point(539, 565);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(148, 229);
            this.listBox3.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(384, 509);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 25);
            this.label6.TabIndex = 16;
            this.label6.Text = "Usuarios";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(591, 509);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 25);
            this.label7.TabIndex = 17;
            this.label7.Text = "Veces";
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ReportForm";
            this.Size = new System.Drawing.Size(1260, 820);
            this.Load += new System.EventHandler(this.ReportForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}
