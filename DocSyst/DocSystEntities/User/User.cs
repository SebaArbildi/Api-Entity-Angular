using System;
using System.ComponentModel.DataAnnotations;

namespace DocSystEntities.User
{
    public class User
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        [Key]
        public string Username { get; private set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public bool IsAdmin { get; set; }

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
