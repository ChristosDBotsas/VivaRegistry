namespace VivaRegistry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GroupEvent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GroupEvents",
                c => new
                    {
                        GroupId = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GroupId, t.EventId })
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: false)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.EventId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GroupEvents", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.GroupEvents", "EventId", "dbo.Events");
            DropIndex("dbo.GroupEvents", new[] { "EventId" });
            DropIndex("dbo.GroupEvents", new[] { "GroupId" });
            DropTable("dbo.GroupEvents");
        }
    }
}
