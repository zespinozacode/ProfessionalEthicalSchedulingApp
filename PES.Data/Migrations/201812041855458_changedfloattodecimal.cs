namespace PES.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedfloattodecimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Day", "Sales", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Employee", "WageAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employee", "WageAmount", c => c.Single(nullable: false));
            AlterColumn("dbo.Day", "Sales", c => c.Single(nullable: false));
        }
    }
}
