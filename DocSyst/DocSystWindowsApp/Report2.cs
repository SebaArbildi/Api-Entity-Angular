using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocSystEntities.User;
using DocSystBusinessLogicInterface.UserBusinessLogicInterface;
using DocSystBusinessLogicInterface.AuditLogBussinesLogicInterface;
using DocSystBusinessLogicImplementation.UserBusinessLogicImplementation;
using DocSystBusinessLogicImplementation.AuditLogBussinesLogicImplementation;
using DocSystDataAccessImplementation.UserDataAccessImplementation;
using DocSystDataAccessImplementation.AuditDataAccessImplementation;

namespace DocSystWindowsApp
{
    public partial class Report2 : UserControl
    {
        private IList<string> usersForReport { get; set; }
        private IList<User> realUserList { get; set; }
        Dictionary<String, Dictionary<DateTime, int>> report { get; set; }

        private IUserBusinessLogic userBusinessLogic { get; set; }
        private IAuditLogBussinesLogic auditLogBussinesLogic { get; set; }

        public Report2()
        {
            InitializeComponent();
            userBusinessLogic = new UserBusinessLogic(new UserDataAccess());
            auditLogBussinesLogic = new AuditLogBussinesLogic(new AuditLogDataAccess());
            usersForReport = new List<string>();
            report = new Dictionary<String, Dictionary<DateTime, int>>();
            Refresh();
        }

        private void Refresh()
        {
            LoadListUser();
        }

        private void LoadListUser()
        {
            this.listBox1.Items.Clear();
            realUserList = userBusinessLogic.GetUsers();
            foreach (User user in realUserList)
            {
                this.listBox1.Items.Add(user.Username);
            }
            if (listBox1.Items.Count > 0)
            {
                listBox1.SelectedIndex = 0;
            }
        }

        private void Report2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime dateFrom = this.dateTimePicker1.Value;
            DateTime dateTo = this.dateTimePicker2.Value;
            report = auditLogBussinesLogic.GetLogsPerUserPerDay(usersForReport, dateFrom,
                dateTo, "Document");
            for (int i = 0; i < report.Count; i++)
            {
                this.listBox2.Items.Add(report.Keys.ElementAt(i));
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexUser = listBox2.SelectedIndex;
            string username = realUserList.ElementAt(indexUser).Username;
            Dictionary<DateTime, int> reportDetail = report[username];
            for (int i = 0; i < reportDetail.Count; i++)
            {
                this.listBox3.Items.Add(reportDetail.Values.ElementAt(i));
                this.listBox4.Items.Add(reportDetail.Keys.ElementAt(i));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int indexUser = listBox1.SelectedIndex;
            string username = realUserList.ElementAt(indexUser).Username;
            usersForReport.Add(username);
            MessageBox.Show("Usuario agregado para reporte");
            Refresh();
        }
    }
}
