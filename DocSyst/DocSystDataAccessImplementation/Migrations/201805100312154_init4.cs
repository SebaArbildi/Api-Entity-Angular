namespace DocSystDataAccessImplementation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AuditLogs", "EntityId", c => c.Guid());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AuditLogs", "EntityId", c => c.Guid(nullable: false));
        }
    }
}
