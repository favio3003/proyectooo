namespace Proyecto1._1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uapcontrollerAndOthers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Materia_Model", "areaModel_id", c => c.Int());
            CreateIndex("dbo.Materia_Model", "areaModel_id");
            AddForeignKey("dbo.Materia_Model", "areaModel_id", "dbo.Area_Model", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Materia_Model", "areaModel_id", "dbo.Area_Model");
            DropIndex("dbo.Materia_Model", new[] { "areaModel_id" });
            DropColumn("dbo.Materia_Model", "areaModel_id");
        }
    }
}
