namespace DocSystDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Texts", "Body_Id", "dbo.Bodies");
            DropForeignKey("dbo.Bodies", "Document_Id", "dbo.Documents");
            DropIndex("dbo.Bodies", new[] { "Document_Id" });
            DropIndex("dbo.Texts", new[] { "Body_Id" });
            RenameColumn(table: "dbo.Texts", name: "Body_Id", newName: "BodyId");
            RenameColumn(table: "dbo.Bodies", name: "Document_Id", newName: "DocumentId");
            AlterColumn("dbo.Bodies", "DocumentId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Texts", "BodyId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Bodies", "DocumentId");
            CreateIndex("dbo.Texts", "BodyId");
            AddForeignKey("dbo.Texts", "BodyId", "dbo.Bodies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Bodies", "DocumentId", "dbo.Documents", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bodies", "DocumentId", "dbo.Documents");
            DropForeignKey("dbo.Texts", "BodyId", "dbo.Bodies");
            DropIndex("dbo.Texts", new[] { "BodyId" });
            DropIndex("dbo.Bodies", new[] { "DocumentId" });
            AlterColumn("dbo.Texts", "BodyId", c => c.Guid());
            AlterColumn("dbo.Bodies", "DocumentId", c => c.Guid());
            RenameColumn(table: "dbo.Bodies", name: "DocumentId", newName: "Document_Id");
            RenameColumn(table: "dbo.Texts", name: "BodyId", newName: "Body_Id");
            CreateIndex("dbo.Texts", "Body_Id");
            CreateIndex("dbo.Bodies", "Document_Id");
            AddForeignKey("dbo.Bodies", "Document_Id", "dbo.Documents", "Id");
            AddForeignKey("dbo.Texts", "Body_Id", "dbo.Bodies", "Id");
        }
    }
}
