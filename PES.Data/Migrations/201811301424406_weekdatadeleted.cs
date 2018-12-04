namespace PES.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class weekdatadeleted : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.WeekData");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.WeekData",
                c => new
                    {
                        WeekId = c.Int(nullable: false, identity: true),
                        ManagerId = c.Guid(nullable: false),
                        MondaySales = c.Single(nullable: false),
                        TuesdaySales = c.Single(nullable: false),
                        WednesdaySales = c.Single(nullable: false),
                        ThursdaySales = c.Single(nullable: false),
                        FridaySales = c.Single(nullable: false),
                        SaturdaySales = c.Single(nullable: false),
                        SundaySales = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.WeekId);
            
        }
    }
}
