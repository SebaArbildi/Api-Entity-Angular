using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocSystWindowsApp
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
            UserControl formatForm = new FormatForm();
            DisplayForm(formatForm);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            UserControl formatForm = new FormatForm();
            DisplayForm(formatForm);
        }

        private void DisplayForm(UserControl form)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(form);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            UserControl formatForm = new FormatForm();
            DisplayForm(formatForm);
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            UserControl reportForm = new ReportForm();
            DisplayForm(reportForm);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            UserControl report2Form = new Report2();
            DisplayForm(report2Form);
        }
    }
}
