using DocSystEntities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSystTest
{
    internal static class Utils
    {
        internal static User CreateUserForTest()
        {
            return new User("Name", "LastName", "UserName", "Password", "Mail", true);
        }
    }
}
