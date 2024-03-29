﻿using DocSystEntities.User;
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
        public Guid Token { get; set; }

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
            Name = user.Name;
            LastName = user.LastName;
            Username = user.Username;
            Password = user.Password;
            Mail = user.Mail;
            IsAdmin = user.IsAdmin;
            Token = user.Token;
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