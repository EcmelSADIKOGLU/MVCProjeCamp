﻿namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_WriterState : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterState", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "WriterState");
        }
    }
}
