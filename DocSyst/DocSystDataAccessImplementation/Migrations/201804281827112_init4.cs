namespace DocSystDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init4 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Texts", name: "Body_Id", newName: "BodyId");
            RenameColumn(table: "dbo.Bodies", name: "Document_Id", newName: "DocumentId");
            RenameIndex(table: "dbo.Bodies", name: "IX_Document_Id", newName: "IX_DocumentId");
            RenameIndex(table: "dbo.Texts", name: "IX_Body_Id", newName: "IX_BodyId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Texts", name: "IX_BodyId", newName: "IX_Body_Id");
            RenameIndex(table: "dbo.Bodies", name: "IX_DocumentId", newName: "IX_Document_Id");
            RenameColumn(table: "dbo.Bodies", name: "DocumentId", newName: "Document_Id");
            RenameColumn(table: "dbo.Texts", name: "BodyId", newName: "Body_Id");
        }
    }
}
