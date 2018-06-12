namespace Proyecto1._1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Solicitud_Model", "area_id", c => c.Int());
            CreateIndex("dbo.Solicitud_Model", "area_id");
            AddForeignKey("dbo.Solicitud_Model", "area_id", "dbo.Area_Model", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Solicitud_Model", "area_id", "dbo.Area_Model");
            DropIndex("dbo.Solicitud_Model", new[] { "area_id" });
            DropColumn("dbo.Solicitud_Model", "area_id");
        }
    }
}
