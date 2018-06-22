namespace DocSystDataAccessImplementation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initFinal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StyleClasses", "Style_Id", c => c.Guid());
            CreateIndex("dbo.StyleClasses", "Style_Id");
            AddForeignKey("dbo.StyleClasses", "Style_Id", "dbo.Styles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StyleClasses", "Style_Id", "dbo.Styles");
            DropIndex("dbo.StyleClasses", new[] { "Style_Id" });
            DropColumn("dbo.StyleClasses", "Style_Id");
        }
    }
}
