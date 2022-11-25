namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_status : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Headings", "HeadingStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Writers", "WriterStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.Writers", "WriterState");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Writers", "WriterState", c => c.Boolean(nullable: false));
            DropColumn("dbo.Writers", "WriterStatus");
            DropColumn("dbo.Headings", "HeadingStatus");
        }
    }
}
