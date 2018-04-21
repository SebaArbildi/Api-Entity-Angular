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
        void Delete(string username);
    }
}
