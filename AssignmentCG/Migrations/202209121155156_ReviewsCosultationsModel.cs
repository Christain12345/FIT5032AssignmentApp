namespace AssignmentCG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReviewsCosultationsModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Consultations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        AvailableTimeId_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AvailableTimes", t => t.AvailableTimeId_Id, cascadeDelete: true)
                .Index(t => t.AvailableTimeId_Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConsultationId = c.Int(nullable: false),
                        GPId = c.Int(nullable: false),
                        Rate = c.Double(nullable: false),
                        Comment = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Consultations", "AvailableTimeId_Id", "dbo.AvailableTimes");
            DropIndex("dbo.Consultations", new[] { "AvailableTimeId_Id" });
            DropTable("dbo.Reviews");
            DropTable("dbo.Consultations");
        }
    }
}
