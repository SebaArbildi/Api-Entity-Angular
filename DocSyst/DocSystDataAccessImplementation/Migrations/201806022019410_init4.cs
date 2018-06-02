namespace DocSystDataAccessImplementation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bodies", "Document_Id", c => c.Guid());
            CreateIndex("dbo.Bodies", "Document_Id");
            AddForeignKey("dbo.Bodies", "Document_Id", "dbo.Documents", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bodies", "Document_Id", "dbo.Documents");
            DropIndex("dbo.Bodies", new[] { "Document_Id" });
            DropColumn("dbo.Bodies", "Document_Id");
        }
    }
}
