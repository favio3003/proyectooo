namespace Proyecto1._1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEstudianteArea : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.estudianteAreas",
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
            DropForeignKey("dbo.estudianteAreas", "est_id", "dbo.Estudiante_Model");
            DropForeignKey("dbo.estudianteAreas", "areaId", "dbo.Area_Model");
            DropIndex("dbo.estudianteAreas", new[] { "est_id" });
            DropIndex("dbo.estudianteAreas", new[] { "areaId" });
            DropTable("dbo.estudianteAreas");
        }
    }
}
