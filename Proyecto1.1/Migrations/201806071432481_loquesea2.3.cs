namespace Proyecto1._1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class loquesea23 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.estudianteArea_Model",
                c => new
                    {
                        estudianteId = c.Int(nullable: false),
                        areaId = c.Int(nullable: false),
                        calificacion = c.Single(nullable: false),
                        est_id = c.Int(),
                    })
                .PrimaryKey(t => new { t.estudianteId, t.areaId })
                .ForeignKey("dbo.Area_Model", t => t.areaId, cascadeDelete: true)
                .ForeignKey("dbo.Estudiante_Model", t => t.est_id)
                .Index(t => t.areaId)
                .Index(t => t.est_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.estudianteArea_Model", "est_id", "dbo.Estudiante_Model");
            DropForeignKey("dbo.estudianteArea_Model", "areaId", "dbo.Area_Model");
            DropIndex("dbo.estudianteArea_Model", new[] { "est_id" });
            DropIndex("dbo.estudianteArea_Model", new[] { "areaId" });
            DropTable("dbo.estudianteArea_Model");
        }
    }
}
