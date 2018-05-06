namespace DocSystDataAccessImplementation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class specificStyle2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SpecificStyles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Implementation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SpecificStyles");
        }
    }
}
