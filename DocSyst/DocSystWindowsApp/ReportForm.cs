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
using DocSystBusinessLogicImplementation.UserBusinessLogicImplementation;
using DocSystDataAccessImplementation.UserDataAccessImplementation;
using DocSystBusinessLogicInterface.AuditLogBussinesLogicInterface;
using DocSystBusinessLogicImplementation.AuditLogBussinesLogicImplementation;
using DocSystDataAccessImplementation.AuditDataAccessImplementation;
using DocSystEntities.Audit;

namespace DocSystWindowsApp
{
    public partial class ReportForm : UserControl
    {
        private IList<string> usersForReport { get; set; }
        private IList<User> realUserList { get; set; }

        private IUserBusinessLogic userBusinessLogic { get; set; }
        private IAuditLogBussinesLogic auditLogBussinesLogic { get; set; }

        public ReportForm()
        {
            InitializeComponent();
            userBusinessLogic = new UserBusinessLogic(new UserDataAccess());
            auditLogBussinesLogic = new AuditLogBussinesLogic(new AuditLogDataAccess());
            usersForReport = new List<string>();
            LoadComboBox();
            Refresh();
        }

        private void LoadComboBox()
        {
            this.comboBox1.Items.Add("Create");
            this.comboBox1.Items.Add("Modify");
            this.comboBox1.Items.Add("Delete");
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime dateFrom = this.dateTimePicker1.Value;
            DateTime dateTo = this.dateTimePicker2.Value;
            string actionSelected = (string)this.comboBox1.SelectedItem;
            ActionPerformed action;
            if(actionSelected == "CREATE")
            {
                action = ActionPerformed.CREATE;
            }else if (actionSelected == "MODIFY")
            {
                action = ActionPerformed.MODIFY;
            }
            else
            {
                action = ActionPerformed.DELETE;
            }
            Dictionary<String, int> report = auditLogBussinesLogic.GetLogsPerUserForAnAction(usersForReport, dateFrom,
                dateTo, "Document", action);
            for(int i = 0; i < report.Count; i++)
            {
                this.listBox2.Items.Add(report.Keys.ElementAt(i));
                this.listBox3.Items.Add(report.Values.ElementAt(i));
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int indexUser = listBox1.SelectedIndex;
            string username = realUserList.ElementAt(indexUser).Username;
            usersForReport.Add(username);
            MessageBox.Show("Usuario agregado para reporte");
            Refresh();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
