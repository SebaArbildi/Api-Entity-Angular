using DocSystDataAccess;
using DocSystEntities.User;

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
            return new User("Name", "LastName", "Username", "Password", "Mail", true);
        }
    }
}
