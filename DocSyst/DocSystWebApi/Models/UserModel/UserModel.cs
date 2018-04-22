using DocSystEntities.User;
using System;

namespace DocSystWebApi.Models.UserModel
{
    public class UserModel : Model<User, UserModel>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public bool IsAdmin { get; set; }

        public UserModel() { }

        public UserModel(User user)
        {
            SetModel(user);
        }

        public override User ToEntity() => new User()
        {
            Name = this.Name,
            LastName = this.LastName,
            Username = this.Username,
            Password = this.Password,
            Mail = this.Mail,
            IsAdmin = this.IsAdmin,
        };

        protected override UserModel SetModel(User user)
        {
            Name = this.Name;
            LastName = this.LastName;
            Username = this.Username;
            Password = this.Password;
            Mail = this.Mail;
            IsAdmin = this.IsAdmin;
            return this;
        }

        public override bool Equals(object obj)
        {
            var otherUser = obj as UserModel;
            if (otherUser == null)
                return false;
            return this.Username == otherUser.Username;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}