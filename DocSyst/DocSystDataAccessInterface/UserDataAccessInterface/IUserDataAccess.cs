using DocSystEntities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSystDataAccessInterface.UserDataAccessInterface
{
    public interface IUserDataAccess
    {
        void Add(User user);
        User Get(string username);
        User Get(Guid token);
        void Delete(string username);
        void Modify(User user);
        IList<User> Get();
        bool Exists(string username);
    }
}
