using DocSystBusinessLogicInterface.AuthorizationBusinessLogicInterface;
using DocSystDataAccessInterface.UserDataAccessInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSystBusinessLogicImplementation.AuthorizationBusinessLogicImplementation
{
    public class LoginBusinessLogic : ILoginBusinessLogic
    {
        private IUserDataAccess userDataAccess;

        public LoginBusinessLogic(IUserDataAccess userDataAccess)
        {
            this.userDataAccess = userDataAccess;
        }

        public Guid Login(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
