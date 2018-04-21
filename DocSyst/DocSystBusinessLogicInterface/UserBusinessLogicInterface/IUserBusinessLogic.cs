using DocSystEntities.User;
using System.Collections.Generic;

namespace DocSystBusinessLogicInterface.UserBusinessLogicInterface
{
    public interface IUserBusinessLogic
    {
        void AddUser(User newUser);
        void DeleteUser(string username);
        void ModifyUser(User newUser);
        IList<User> GetUsers();
        User GetUser(string username);
    }
}
