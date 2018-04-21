using System;
using DocSystDataAccessInterface.UserDataAccessInterface;
using DocSystEntities.User;
using System.Linq;

namespace DocSystDataAccess.UserDataAccessImplementation
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
            throw new NotImplementedException();
        }
    }
}
