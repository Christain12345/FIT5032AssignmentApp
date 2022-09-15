namespace AssignmentCG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConsultationModelUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Consultations", "AvailableTimeId_Id", "dbo.AvailableTimes");
            DropForeignKey("dbo.Consultations", "Patient_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Consultations", new[] { "AvailableTimeId_Id" });

            DropTable("dbo.Consultations");
            CreateTable(
                "dbo.Consultations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AvailableTime_Id = c.Int(nullable: false),
                        Patient_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AvailableTimes", t => t.AvailableTime_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Patient_Id)
                .Index(t => t.AvailableTime_Id);
            
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Consultations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        AvailableTimeId_Id = c.Int(nullable: false),
                        Patient_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Consultations", "Patient_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Consultations", "AvailableTime_Id", "dbo.AvailableTimes");
            DropIndex("dbo.Consultations", new[] { "AvailableTime_Id" });
            DropTable("dbo.Consultations");
            CreateIndex("dbo.Consultations", "AvailableTimeId_Id");
            AddForeignKey("dbo.Consultations", "Patient_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Consultations", "AvailableTimeId_Id", "dbo.AvailableTimes", "Id", cascadeDelete: true);
        }
    }
}
