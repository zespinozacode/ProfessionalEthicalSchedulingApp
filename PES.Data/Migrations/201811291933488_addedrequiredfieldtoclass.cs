namespace PES.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedrequiredfieldtoclass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WeekData", "ManagerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WeekData", "ManagerId");
        }
    }
}
