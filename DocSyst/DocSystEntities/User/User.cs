using System.ComponentModel.DataAnnotations;

namespace DocSystEntities.User
{
    public class User
    {
        private string name;
        private string lastName;
        private string username;
        private string password;
        private string mail;
        private bool isAdmin;

        public User() { }

        public User(string name, string lastName, string userName, string password, string mail, bool isAdmin)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Username = userName;
            this.Password = password;
            this.Mail = mail;
            this.IsAdmin = isAdmin;
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
            }
        }

        [Key]
        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public string Mail
        {
            get
            {
                return mail;
            }

            set
            {
                mail = value;
            }
        }

        public bool IsAdmin
        {
            get
            {
                return isAdmin;
            }

            set
            {
                isAdmin = value;
            }
        }

        public override bool Equals(object obj)
        {
            bool equals = false;
            User user = (User)obj;
            if (this.Username.Equals(user.Username))
            {
                equals = true;
            }
            return equals;
        }
    }
}
