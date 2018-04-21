using DocSystEntities.User;

namespace DocSystBusinessLogicInterface.UserBusinessLogicInterface
{
    public interface IUserBusinessLogic
    {
        void AddUser(User newUser);
        void DeleteUser(string username);
        void ModifyUser(User newUser);
    }
}
