using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSystEntities.User
{
    public class User
    {
        private string name;
        private string lastName;
        private string userName;
        private string password;
        private string mail;
        private bool isAdmin;

        public User() { }

        public User(string name, string lastName, string userName, string password, string mail, bool isAdmin)
        {
            this.name = name;
            this.lastName = lastName;
            this.userName = userName;
            this.password = password;
            this.mail = mail;
            this.isAdmin = isAdmin;
        }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Mail { get; set; }

        public bool IsAdmin { get; set; }
    }
}
