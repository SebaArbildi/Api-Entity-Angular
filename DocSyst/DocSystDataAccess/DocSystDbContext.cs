using DocSystEntities.User;
using System.Data.Entity;

namespace DocSystDataAccess
{
    public class DocSystDbContext: DbContext
    {
        public DocSystDbContext() { }
        public DbSet<User> Users { get; set; }
    }
}
