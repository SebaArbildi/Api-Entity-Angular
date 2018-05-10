namespace DocSystDataAccessImplementation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bodies",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OwnStyleClass = c.String(),
                        Align = c.Int(),
                        DocumentId = c.Guid(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Documents", t => t.DocumentId)
                .Index(t => t.DocumentId);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        LastModifyDate = c.DateTime(nullable: false),
                        OwnStyleClass = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Texts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TextContent = c.String(),
                        OwnStyleClass = c.String(),
                        BodyId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bodies", t => t.BodyId)
                .Index(t => t.BodyId);
            
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        LastName = c.String(),
                        Password = c.String(),
                        Mail = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserName);
            
            DropForeignKey("dbo.Texts", "BodyId", "dbo.Bodies");
            DropForeignKey("dbo.Bodies", "DocumentId", "dbo.Documents");
            DropIndex("dbo.Texts", new[] { "BodyId" });
            DropIndex("dbo.Bodies", new[] { "DocumentId" });
            DropTable("dbo.Texts");
            DropTable("dbo.Documents");
            DropTable("dbo.Bodies");
        }
    }
}
