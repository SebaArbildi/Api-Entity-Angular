using DocSystEntities.Audit;
using DocSystEntities.DocumentStructure;
using DocSystEntities.User;
using System.Data.Entity;

namespace DocSystDataAccessImplementation
{
    public class DocSystDbContext: DbContext
    {
        public DocSystDbContext() { }
        public DbSet<Body> Bodys { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Margin> Margins { get; set; }
        public DbSet<Paragraph> Paragraphs { get; set; }
        public DbSet<Text> Texts { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }

    }
}