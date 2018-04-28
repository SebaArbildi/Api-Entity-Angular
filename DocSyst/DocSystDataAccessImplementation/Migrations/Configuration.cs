<<<<<<< HEAD:DocSyst/DocSystDataAccess/Migrations/Configuration.cs
namespace DocSystDataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DocSystDataAccess.DocSystDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DocSystDataAccess.DocSystDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
=======
namespace DocSystDataAccessImplementation.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DocSystDataAccessImplementation.DocSystDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "DocSystDataAccess.DocSystDbContext";
        }

        protected override void Seed(DocSystDataAccessImplementation.DocSystDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
>>>>>>> develop:DocSyst/DocSystDataAccessImplementation/Migrations/Configuration.cs
