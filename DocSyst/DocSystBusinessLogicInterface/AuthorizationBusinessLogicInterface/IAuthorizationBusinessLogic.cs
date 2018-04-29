using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSystBusinessLogicInterface.AuthorizationBusinessLogicInterface
{
    public interface IAuthorizationBusinessLogic
    {
        bool IsAValidToken(Guid token);
        bool IsAdmin(Guid token);
    }
}
