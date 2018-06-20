using DocSystBusinessLogicImplementation.AuthorizationBusinessLogicImplementation;
using DocSystBusinessLogicInterface.AuthorizationBusinessLogicInterface;
using DocSystDataAccessImplementation.UserDataAccessImplementation;
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
    public partial class Login : Form
    {
        private ILoginBusinessLogic LoginBusinessLogic { get; set; }
        private IAuthorizationBusinessLogic AuthBusinessLogic { get; set; }

        public Login()
        {
            InitializeComponent();
            LoginBusinessLogic = new LoginBusinessLogic(new UserDataAccess());
            AuthBusinessLogic = new AuthorizationBusinessLogic(new UserDataAccess());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = this.textBox1.Text;
            string password = this.textBox2.Text;

            try
            {
                Guid token = LoginBusinessLogic.Login(username, password);
                if (AuthBusinessLogic.IsAdmin(token))
                {
                    this.Hide();
                    var principal = new Principal();
                    principal.Show();
                }
                else
                {
                    MessageBox.Show("Usuario no es admin");
                }
            }
            catch
            {
                MessageBox.Show("Username o password son incorrectos");
            }
        }
    }
}
