namespace VivaRegistry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGroupsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        ApplicationId = c.Int(nullable: false),
                        Code = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.GroupId)
                .ForeignKey("dbo.Applications", t => t.ApplicationId, cascadeDelete: true)
                .Index(t => t.ApplicationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Groups", "ApplicationId", "dbo.Applications");
            DropIndex("dbo.Groups", new[] { "ApplicationId" });
            DropTable("dbo.Groups");
        }
    }
}
