using DocSystEntities.ObserverInterface;
using DocSystEntities.StyleStructure;
using DocSystEntities.User;
using System.Data.Entity;

namespace DocSystDataAccessImplementation
{
    public class DocSystDbContext: DbContext
    {
        public DocSystDbContext() { }
        public DbSet<User> Users { get; set; }
        public DbSet<SpecificStyle> SpecificStyles { get; set; }
        public DbSet<Style> Styles { get; set; }
        public DbSet<StyleClass> StyleClasses { get; set; }
        public DbSet<Format> Formats { get; set; }
    }
}
