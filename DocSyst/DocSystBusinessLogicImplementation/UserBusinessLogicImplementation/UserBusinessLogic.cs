using DocSystBusinessLogicInterface.UserBusinessLogicInterface;
using DocSystDataAccessInterface.UserDataAccessInterface;

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
    }
}
