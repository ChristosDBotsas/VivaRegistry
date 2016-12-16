namespace VivaRegistry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteKeyColumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Applications", "ApplicationKey");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Applications", "ApplicationKey", c => c.Int(nullable: false));
        }
    }
}
