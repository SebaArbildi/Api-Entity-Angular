using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSystBusinessLogicInterface.AuthorizationBusinessLogicInterface
{
    public interface ILoginBusinessLogic
    {
        Guid Login(string username, string password);
    }
}
