using DocSystDataAccessImplementation;
using DocSystEntities.User;
using System;

namespace DocSystTest
{
    internal static class Utils
    {

        private static Random random = new Random();
        internal static void DeleteBd()
        {
            using (DocSystDbContext context = new DocSystDbContext())
            {
                context.Database.Delete();
            }
        }

        internal static User CreateUserForTest()
        {          
            return new User("Name", "LastName", random.Next().ToString(), "Password", "Mail", true);
        }
    }
}
