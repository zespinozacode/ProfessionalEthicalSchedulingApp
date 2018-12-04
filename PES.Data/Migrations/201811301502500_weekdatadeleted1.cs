namespace PES.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class weekdatadeleted1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Day",
                c => new
                    {
                        DayId = c.Int(nullable: false, identity: true),
                        ManagerId = c.Guid(nullable: false),
                        DayOfWeek = c.Int(nullable: false),
                        Sales = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.DayId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Day");
        }
    }
}
