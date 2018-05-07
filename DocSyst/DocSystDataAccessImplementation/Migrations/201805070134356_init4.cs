namespace DocSystDataAccessImplementation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Formats",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.StyleClasses", "Format_Id", c => c.Guid());
            CreateIndex("dbo.StyleClasses", "Format_Id");
            AddForeignKey("dbo.StyleClasses", "Format_Id", "dbo.Formats", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StyleClasses", "Format_Id", "dbo.Formats");
            DropIndex("dbo.StyleClasses", new[] { "Format_Id" });
            DropColumn("dbo.StyleClasses", "Format_Id");
            DropTable("dbo.Formats");
        }
    }
}
