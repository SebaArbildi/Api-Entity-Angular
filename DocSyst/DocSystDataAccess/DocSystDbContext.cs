using DocSystEntities.DocumentStructure;
using DocSystEntities.User;
using System.Data.Entity;

namespace DocSystDataAccess
{
    public class DocSystDbContext: DbContext
    {
        public DocSystDbContext() { }
        public DbSet<User> Users { get; set; }
        public DbSet<Document> Document { get; set; }
        public DbSet<Body> Body { get; set; }
        public DbSet<Margin> Margin { get; set; }
        public DbSet<Paragraph> Paragraph { get; set; }
        public DbSet<Paragraph> Text { get; set; }

    }
}
