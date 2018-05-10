namespace DocSystDataAccessImplementation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuditLogs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OperationDate = c.DateTime(nullable: false),
                        EntityType = c.String(),
                        EntityId = c.Guid(nullable: false),
                        ExecutingUserId = c.String(),
                        Action = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Bodies",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OwnStyleClass = c.String(),
                        Align = c.Int(nullable: false),
                        DocumentId = c.Guid(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Documents", t => t.DocumentId)
                .Index(t => t.DocumentId);
            
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
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifyDate = c.DateTime(nullable: false),
                        OwnStyleClass = c.String(),
                        CreatorUser_Username = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatorUser_Username)
                .Index(t => t.CreatorUser_Username);
            
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
            DropForeignKey("dbo.Bodies", "DocumentId", "dbo.Documents");
            DropForeignKey("dbo.Documents", "CreatorUser_Username", "dbo.Users");
            DropForeignKey("dbo.Texts", "BodyId", "dbo.Bodies");
            DropIndex("dbo.Documents", new[] { "CreatorUser_Username" });
            DropIndex("dbo.Texts", new[] { "BodyId" });
            DropIndex("dbo.Bodies", new[] { "DocumentId" });
            DropTable("dbo.Users");
            DropTable("dbo.Documents");
            DropTable("dbo.Texts");
            DropTable("dbo.Bodies");
            DropTable("dbo.AuditLogs");
        }
    }
}
