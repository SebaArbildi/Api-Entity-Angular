using System;
using DocSystDataAccessInterface.UserDataAccessInterface;
using DocSystEntities.User;
using System.Linq;
using System.Collections.Generic;

namespace DocSystDataAccessImplementation.UserDataAccessImplementation
{
    public class UserDataAccess : IUserDataAccess
    {
        public void Add(User user)
        {
            using (DocSystDbContext context = new DocSystDbContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public User Get(string username)
        {
            User user = null;
            using (DocSystDbContext context = new DocSystDbContext())
            {
                user = context.Users.Where(userDb => userDb.Username == username).FirstOrDefault();
            }
            return user;
        }

        public void Delete(string username)
        {
            User user = Get(username);
            using (DocSystDbContext context = new DocSystDbContext())
            {
                context.Users.Attach(user);
                context.Users.Remove(user);
                context.SaveChanges();
            }
        }

        public void Modify(User newUser)
        {
            using (DocSystDbContext context = new DocSystDbContext())
            {
                User actualUser = context.Users.Where(userDb => userDb.Username == newUser.Username).FirstOrDefault();
                context.Entry(actualUser).CurrentValues.SetValues(newUser);
                context.SaveChanges();
            }
        }

        public IList<User> Get()
        {
            IList<User> users = null;
            using (DocSystDbContext context = new DocSystDbContext())
            {
                users = context.Users.ToList<User>();
            }
            return users;
        }

        public bool Exists(string username)
        {
            bool exists = false;
            using (DocSystDbContext context = new DocSystDbContext())
            {
                exists = context.Users.Any(userDb => userDb.Username == username);
            }
            return exists;
        }

        public User Get(Guid token)
        {
            User user = null;
            using (DocSystDbContext context = new DocSystDbContext())
            {
                user = context.Users.Where(userDb => userDb.Token == token).FirstOrDefault();
            }
            return user;
        }
    }
}