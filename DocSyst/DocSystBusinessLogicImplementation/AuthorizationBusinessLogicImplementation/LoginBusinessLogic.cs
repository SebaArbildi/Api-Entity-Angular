using DocSystBusinessLogicInterface.AuthorizationBusinessLogicInterface;
using DocSystDataAccessInterface.UserDataAccessInterface;
using DocSystEntities.User;
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
            Guid token;
            if (userDataAccess.Exists(username))
            {
                User user = userDataAccess.Get(username);
                if (user.Password == password)
                {
                    token = Guid.NewGuid();
                    user.Token = token;
                    userDataAccess.Modify(user);
                }
                else
                {
                    throw new ArgumentException("Incorrect password");
                }
            }
            else
            {
                throw new ArgumentException("Username doesn't exists");
            }
            return token;
        }
    }
}
