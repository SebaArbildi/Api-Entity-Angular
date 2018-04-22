using DocSystDataAccess;
using DocSystEntities.User;
using System;

namespace DocSystTest
{
    internal static class Utils
    {
        internal static void DeleteBd()
        {
            using (DocSystDbContext context = new DocSystDbContext())
            {
                context.Database.Delete();
            }
        }

        internal static User CreateUserForTest()
        {
            Random random = new Random();
            return new User("Name", "LastName", random.Next().ToString(), "Password", "Mail", true);
        }
    }
}
