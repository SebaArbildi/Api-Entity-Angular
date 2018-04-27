using DocSystEntities.User;
using System.Data.Entity;

namespace DocSystDataAccessImplementation
{
    public class DocSystDbContext: DbContext
    {
        public DocSystDbContext() { }
        public DbSet<User> Users { get; set; }
    }
}
