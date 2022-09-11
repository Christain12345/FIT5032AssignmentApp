namespace AssignmentCG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AvailableTimeModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AvailableTimes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        GP_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.GP_Id, cascadeDelete: true)
                .Index(t => t.GP_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AvailableTimes", "GP_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AvailableTimes", new[] { "GP_Id" });
            DropTable("dbo.AvailableTimes");
        }
    }
}
