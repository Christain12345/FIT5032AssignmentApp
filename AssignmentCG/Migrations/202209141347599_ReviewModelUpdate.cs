namespace AssignmentCG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReviewModelUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "Consultation_Id", c => c.Int());
            AddColumn("dbo.Reviews", "GP_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Reviews", "Consultation_Id");
            CreateIndex("dbo.Reviews", "GP_Id");
            AddForeignKey("dbo.Reviews", "Consultation_Id", "dbo.Consultations", "Id");
            AddForeignKey("dbo.Reviews", "GP_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Reviews", "ConsultationId");
            DropColumn("dbo.Reviews", "GPId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "GPId", c => c.Int(nullable: false));
            AddColumn("dbo.Reviews", "ConsultationId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Reviews", "GP_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reviews", "Consultation_Id", "dbo.Consultations");
            DropIndex("dbo.Reviews", new[] { "GP_Id" });
            DropIndex("dbo.Reviews", new[] { "Consultation_Id" });
            DropColumn("dbo.Reviews", "GP_Id");
            DropColumn("dbo.Reviews", "Consultation_Id");
        }
    }
}
