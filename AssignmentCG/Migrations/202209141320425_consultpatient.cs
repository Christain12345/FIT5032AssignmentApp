namespace AssignmentCG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class consultpatient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Consultations", "Patient_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Consultations", "Patient_Id");
            AddForeignKey("dbo.Consultations", "Patient_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Consultations", "Patient_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Consultations", new[] { "Patient_Id" });
            DropColumn("dbo.Consultations", "Patient_Id");
        }
    }
}
