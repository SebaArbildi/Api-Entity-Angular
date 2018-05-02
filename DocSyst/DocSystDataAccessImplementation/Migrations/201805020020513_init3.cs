namespace DocSystDataAccessImplementation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Documents", "CreatorUser_Username", c => c.String(maxLength: 128));
            CreateIndex("dbo.Documents", "CreatorUser_Username");
            AddForeignKey("dbo.Documents", "CreatorUser_Username", "dbo.Users", "Username");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Documents", "CreatorUser_Username", "dbo.Users");
            DropIndex("dbo.Documents", new[] { "CreatorUser_Username" });
            DropColumn("dbo.Documents", "CreatorUser_Username");
        }
    }
}
