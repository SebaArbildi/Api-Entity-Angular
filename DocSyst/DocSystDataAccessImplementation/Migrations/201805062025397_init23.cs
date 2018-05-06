namespace DocSystDataAccessImplementation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init23 : DbMigration
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
            
            CreateTable(
                "dbo.Styles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Implementation_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SpecificStyles", t => t.Implementation_Id)
                .Index(t => t.Implementation_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        LastName = c.String(),
                        Password = c.String(),
                        Mail = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                        Token = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Username);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Styles", "Implementation_Id", "dbo.SpecificStyles");
            DropIndex("dbo.Styles", new[] { "Implementation_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Styles");
            DropTable("dbo.SpecificStyles");
        }
    }
}
