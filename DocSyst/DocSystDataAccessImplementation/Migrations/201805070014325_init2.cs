namespace DocSystDataAccessImplementation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StyleClasses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        InheritedStyleClass_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StyleClasses", t => t.InheritedStyleClass_Id)
                .Index(t => t.InheritedStyleClass_Id);
            
            AddColumn("dbo.Styles", "StyleClass_Id", c => c.Guid());
            AddColumn("dbo.Styles", "StyleClass_Id1", c => c.Guid());
            CreateIndex("dbo.Styles", "StyleClass_Id");
            CreateIndex("dbo.Styles", "StyleClass_Id1");
            AddForeignKey("dbo.Styles", "StyleClass_Id", "dbo.StyleClasses", "Id");
            AddForeignKey("dbo.Styles", "StyleClass_Id1", "dbo.StyleClasses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Styles", "StyleClass_Id1", "dbo.StyleClasses");
            DropForeignKey("dbo.StyleClasses", "InheritedStyleClass_Id", "dbo.StyleClasses");
            DropForeignKey("dbo.Styles", "StyleClass_Id", "dbo.StyleClasses");
            DropIndex("dbo.Styles", new[] { "StyleClass_Id1" });
            DropIndex("dbo.Styles", new[] { "StyleClass_Id" });
            DropIndex("dbo.StyleClasses", new[] { "InheritedStyleClass_Id" });
            DropColumn("dbo.Styles", "StyleClass_Id1");
            DropColumn("dbo.Styles", "StyleClass_Id");
            DropTable("dbo.StyleClasses");
        }
    }
}
