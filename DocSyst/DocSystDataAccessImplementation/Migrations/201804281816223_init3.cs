namespace DocSystDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Texts", "BodyId", "dbo.Bodies");
            DropForeignKey("dbo.Bodies", "DocumentId", "dbo.Documents");
            DropIndex("dbo.Bodies", new[] { "DocumentId" });
            DropIndex("dbo.Texts", new[] { "BodyId" });
            RenameColumn(table: "dbo.Texts", name: "BodyId", newName: "Body_Id");
            RenameColumn(table: "dbo.Bodies", name: "DocumentId", newName: "Document_Id");
            AlterColumn("dbo.Bodies", "Document_Id", c => c.Guid());
            AlterColumn("dbo.Texts", "Body_Id", c => c.Guid());
            CreateIndex("dbo.Bodies", "Document_Id");
            CreateIndex("dbo.Texts", "Body_Id");
            AddForeignKey("dbo.Texts", "Body_Id", "dbo.Bodies", "Id");
            AddForeignKey("dbo.Bodies", "Document_Id", "dbo.Documents", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bodies", "Document_Id", "dbo.Documents");
            DropForeignKey("dbo.Texts", "Body_Id", "dbo.Bodies");
            DropIndex("dbo.Texts", new[] { "Body_Id" });
            DropIndex("dbo.Bodies", new[] { "Document_Id" });
            AlterColumn("dbo.Texts", "Body_Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Bodies", "Document_Id", c => c.Guid(nullable: false));
            RenameColumn(table: "dbo.Bodies", name: "Document_Id", newName: "DocumentId");
            RenameColumn(table: "dbo.Texts", name: "Body_Id", newName: "BodyId");
            CreateIndex("dbo.Texts", "BodyId");
            CreateIndex("dbo.Bodies", "DocumentId");
            AddForeignKey("dbo.Bodies", "DocumentId", "dbo.Documents", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Texts", "BodyId", "dbo.Bodies", "Id", cascadeDelete: true);
        }
    }
}
