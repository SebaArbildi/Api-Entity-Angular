namespace DocSystDataAccessImplementation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init345 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Styles", "Implementation_Id", "dbo.SpecificStyles");
            DropIndex("dbo.Styles", new[] { "Implementation_Id" });
            AddColumn("dbo.Styles", "Type", c => c.Int(nullable: false));
            AddColumn("dbo.Styles", "Value", c => c.String());
            DropColumn("dbo.Styles", "Implementation_Id");
            DropTable("dbo.SpecificStyles");
        }
        
        public override void Down()
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
            
            AddColumn("dbo.Styles", "Implementation_Id", c => c.Guid());
            DropColumn("dbo.Styles", "Value");
            DropColumn("dbo.Styles", "Type");
            CreateIndex("dbo.Styles", "Implementation_Id");
            AddForeignKey("dbo.Styles", "Implementation_Id", "dbo.SpecificStyles", "Id");
        }
    }
}
