namespace VivaRegistry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Creation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applications",
                c => new
                    {
                        ApplicationId = c.Guid(nullable: false, identity: true),
                        ApplicationKey = c.Int(nullable: false),
                        ApplicationName = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ApplicationId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        EventGenerationDate = c.DateTime(nullable: false),
                        AppId = c.Guid(nullable: false),
                        LogId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Applications", t => t.AppId, cascadeDelete: true)
                .ForeignKey("dbo.LogLevels", t => t.LogId, cascadeDelete: true)
                .Index(t => t.AppId)
                .Index(t => t.LogId);
            
            CreateTable(
                "dbo.LogLevels",
                c => new
                    {
                        LogLevelId = c.Int(nullable: false, identity: true),
                        LogLevelName = c.String(),
                    })
                .PrimaryKey(t => t.LogLevelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "LogId", "dbo.LogLevels");
            DropForeignKey("dbo.Events", "AppId", "dbo.Applications");
            DropIndex("dbo.Events", new[] { "LogId" });
            DropIndex("dbo.Events", new[] { "AppId" });
            DropTable("dbo.LogLevels");
            DropTable("dbo.Events");
            DropTable("dbo.Applications");
        }
    }
}
