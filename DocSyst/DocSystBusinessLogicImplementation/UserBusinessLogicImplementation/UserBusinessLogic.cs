using System;
using DocSystBusinessLogicInterface.UserBusinessLogicInterface;
using DocSystDataAccessInterface.UserDataAccessInterface;
using DocSystEntities.User;

namespace DocSystBusinessLogicImplementation.UserBusinessLogicImplementation
{
    public class UserBusinessLogic: IUserBusinessLogic
    {
        private IUserDataAccess userDataAccess;

        public UserBusinessLogic() { }

        public UserBusinessLogic(IUserDataAccess userDataAccess)
        {
            this.userDataAccess = userDataAccess;
        }

        public void AddUser(User newUser)
        {
            throw new NotImplementedException();
        }
    }
}
