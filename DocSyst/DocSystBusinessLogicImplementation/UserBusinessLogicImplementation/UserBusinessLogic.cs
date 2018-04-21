using System;
using DocSystBusinessLogicInterface.UserBusinessLogicInterface;
using DocSystDataAccessInterface.UserDataAccessInterface;
using DocSystEntities.User;

namespace DocSystBusinessLogicImplementation.UserBusinessLogicImplementation
{
    public class UserBusinessLogic : IUserBusinessLogic
    {
        private IUserDataAccess userDataAccess;

        public UserBusinessLogic() { }

        public UserBusinessLogic(IUserDataAccess userDataAccess)
        {
            this.userDataAccess = userDataAccess;
        }

        public void AddUser(User newUser)
        {
            if (!UserIsNull(newUser))
            {
                if (!UserExists(newUser))
                {
                    try
                    {
                        userDataAccess.Add(newUser);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                else
                {
                    throw new DuplicateWaitObjectException(newUser.Username + " already exists");
                }
            }
            else
            {
                throw new ArgumentNullException("Null references");
            }
        }

        public void DeleteUser(string username)
        {
            throw new NotImplementedException();
        }

        public void ModifyUser(User newUser)
        {
            throw new NotImplementedException();
        }

        private bool UserExists(User newUser)
        {
            return userDataAccess.Exists(newUser.Username);
        }

        private bool UserIsNull(User newUser)
        {
            return newUser == null || newUser.Username == null || newUser.Password == null || newUser.Name == null
                || newUser.Mail == null || newUser.LastName == null;
        }
    }
}
