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
                if (!UserExists(newUser.Username))
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
            if (username != null)
            {
                if (UserExists(username))
                {
                    try
                    {
                        userDataAccess.Delete(username);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                else
                {
                    throw new ArgumentException("Username doesn't exist", username);
                }
            }
            else
            {
                throw new ArgumentNullException(username);
            }
        }

        public void ModifyUser(User newUser)
        {
            if (!UserIsNull(newUser))
            {
                if (UserExists(newUser.Username))
                {
                    try
                    {
                        userDataAccess.Modify(newUser);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                else
                {
                    throw new ArgumentException("Username doesn't exist", newUser.Username);
                }
            }
            else
            {
                throw new ArgumentNullException("Null references");
            }
        }

        private bool UserExists(string usernameer)
        {
            return userDataAccess.Exists(usernameer);
        }

        private bool UserIsNull(User newUser)
        {
            return newUser == null || newUser.Username == null || newUser.Password == null || newUser.Name == null
                || newUser.Mail == null || newUser.LastName == null;
        }
    }
}
