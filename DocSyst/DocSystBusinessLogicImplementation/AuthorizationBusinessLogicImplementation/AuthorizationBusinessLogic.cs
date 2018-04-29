using System;
using DocSystBusinessLogicInterface.AuthorizationBusinessLogicInterface;

namespace DocSystBusinessLogicImplementation.AuthorizationBusinessLogicImplementation
{
    public class AuthorizationBusinessLogic : IAuthorizationBusinessLogic
    {
        public bool IsAdmin(Guid token)
        {
            throw new NotImplementedException();
        }

        public bool IsAValidToken(Guid token)
        {
            throw new NotImplementedException();
        }
    }
}
