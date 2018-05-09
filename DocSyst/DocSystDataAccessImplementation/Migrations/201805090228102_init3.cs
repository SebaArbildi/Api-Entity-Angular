namespace DocSystDataAccessImplementation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuditLogs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OperationDate = c.DateTime(nullable: false),
                        EntityType = c.String(),
                        EntityId = c.Guid(nullable: false),
                        ExecutingUserId = c.Guid(nullable: false),
                        Action = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AuditLogs");
        }
    }
}
