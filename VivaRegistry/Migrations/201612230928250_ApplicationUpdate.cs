namespace VivaRegistry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "AppId", "dbo.Applications");
            DropIndex("dbo.Events", new[] { "AppId" });
            DropPrimaryKey("dbo.Applications");
            AddColumn("dbo.Applications", "ApplicationKey", c => c.String(maxLength: 80));
            AddColumn("dbo.Applications", "ApplicationEmail", c => c.String());
            DropColumn("dbo.Applications", "ApplicationId");
            DropColumn("dbo.Events", "AppId");
            AddColumn("dbo.Applications", "ApplicationId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Events", "AppId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Applications", "ApplicationId");
            CreateIndex("dbo.Events", "AppId");
            AddForeignKey("dbo.Events", "AppId", "dbo.Applications", "ApplicationId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "AppId", "dbo.Applications");
            DropIndex("dbo.Events", new[] { "AppId" });
            DropPrimaryKey("dbo.Applications");
            DropColumn("dbo.Applications", "ApplicationId");
            DropColumn("dbo.Events", "AppId");
            AddColumn("dbo.Applications", "ApplicationKey", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Events", "AppId", c => c.Int(nullable: false));
            DropColumn("dbo.Applications", "ApplicationEmail");
            DropColumn("dbo.Applications", "ApplicationKey");
            AddPrimaryKey("dbo.Applications", "ApplicationId");
            CreateIndex("dbo.Events", "AppId");
            AddForeignKey("dbo.Events", "AppId", "dbo.Applications", "ApplicationId", cascadeDelete: true);
        }
    }
}
