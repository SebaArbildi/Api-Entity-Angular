using System;
using DocSystBusinessLogicInterface.AuthorizationBusinessLogicInterface;
using DocSystDataAccessInterface.UserDataAccessInterface;
using DocSystEntities.User;

namespace DocSystBusinessLogicImplementation.AuthorizationBusinessLogicImplementation
{
    public class AuthorizationBusinessLogic : IAuthorizationBusinessLogic
    {
        private IUserDataAccess userDataAccess;

        public AuthorizationBusinessLogic(IUserDataAccess userDataAccess)
        {
            this.userDataAccess = userDataAccess;
        }

        public bool IsAdmin(Guid token)
        {
            bool isAdmin = false;
            User user = userDataAccess.Get(token);
            if(user != null)
            {
                isAdmin = user.IsAdmin;
            }
            return isAdmin;
        }

        public bool IsAValidToken(Guid token)
        {
            User user = userDataAccess.Get(token);
            return user != null;
        }
    }
}
