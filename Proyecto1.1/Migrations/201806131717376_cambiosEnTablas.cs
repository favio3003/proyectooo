namespace Proyecto1._1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambiosEnTablas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Estudiante_ModelArea_Model", "Estudiante_Model_id", "dbo.Estudiante_Model");
            DropForeignKey("dbo.Estudiante_ModelArea_Model", "Area_Model_id", "dbo.Area_Model");
            DropForeignKey("dbo.estudianteArea_Model", "areaId", "dbo.Area_Model");
            DropForeignKey("dbo.estudianteArea_Model", "est_id", "dbo.Estudiante_Model");
            DropForeignKey("dbo.Solicitud_Model", "area_id", "dbo.Area_Model");
            DropIndex("dbo.estudianteArea_Model", new[] { "areaId" });
            DropIndex("dbo.estudianteArea_Model", new[] { "est_id" });
            DropIndex("dbo.Solicitud_Model", new[] { "area_id" });
            DropIndex("dbo.Estudiante_ModelArea_Model", new[] { "Estudiante_Model_id" });
            DropIndex("dbo.Estudiante_ModelArea_Model", new[] { "Area_Model_id" });
            CreateTable(
                "dbo.estudianteMateria_Model",
                c => new
                    {
                        estudianteId = c.Int(nullable: false),
                        materiaId = c.Int(nullable: false),
                        calificacion = c.Single(nullable: false),
                        comentario = c.String(),
                        est_id = c.Int(),
                    })
                .PrimaryKey(t => new { t.estudianteId, t.materiaId })
                .ForeignKey("dbo.Estudiante_Model", t => t.est_id)
                .ForeignKey("dbo.Materia_Model", t => t.materiaId, cascadeDelete: true)
                .Index(t => t.materiaId)
                .Index(t => t.est_id);
            
            CreateTable(
                "dbo.Materia_ModelEstudiante_Model",
                c => new
                    {
                        Materia_Model_id = c.Int(nullable: false),
                        Estudiante_Model_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Materia_Model_id, t.Estudiante_Model_id })
                .ForeignKey("dbo.Materia_Model", t => t.Materia_Model_id, cascadeDelete: true)
                .ForeignKey("dbo.Estudiante_Model", t => t.Estudiante_Model_id, cascadeDelete: true)
                .Index(t => t.Materia_Model_id)
                .Index(t => t.Estudiante_Model_id);
            
            AddColumn("dbo.Solicitud_Model", "materia_id", c => c.Int());
            CreateIndex("dbo.Solicitud_Model", "materia_id");
            AddForeignKey("dbo.Solicitud_Model", "materia_id", "dbo.Materia_Model", "id");
            DropColumn("dbo.Solicitud_Model", "area_id");
            DropTable("dbo.estudianteArea_Model");
            DropTable("dbo.Estudiante_ModelArea_Model");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Estudiante_ModelArea_Model",
                c => new
                    {
                        Estudiante_Model_id = c.Int(nullable: false),
                        Area_Model_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Estudiante_Model_id, t.Area_Model_id });
            
            CreateTable(
                "dbo.estudianteArea_Model",
                c => new
                    {
                        estudianteId = c.Int(nullable: false),
                        areaId = c.Int(nullable: false),
                        calificacion = c.Single(nullable: false),
                        comentario = c.String(),
                        est_id = c.Int(),
                    })
                .PrimaryKey(t => new { t.estudianteId, t.areaId });
            
            AddColumn("dbo.Solicitud_Model", "area_id", c => c.Int());
            DropForeignKey("dbo.Solicitud_Model", "materia_id", "dbo.Materia_Model");
            DropForeignKey("dbo.estudianteMateria_Model", "materiaId", "dbo.Materia_Model");
            DropForeignKey("dbo.estudianteMateria_Model", "est_id", "dbo.Estudiante_Model");
            DropForeignKey("dbo.Materia_ModelEstudiante_Model", "Estudiante_Model_id", "dbo.Estudiante_Model");
            DropForeignKey("dbo.Materia_ModelEstudiante_Model", "Materia_Model_id", "dbo.Materia_Model");
            DropIndex("dbo.Materia_ModelEstudiante_Model", new[] { "Estudiante_Model_id" });
            DropIndex("dbo.Materia_ModelEstudiante_Model", new[] { "Materia_Model_id" });
            DropIndex("dbo.Solicitud_Model", new[] { "materia_id" });
            DropIndex("dbo.estudianteMateria_Model", new[] { "est_id" });
            DropIndex("dbo.estudianteMateria_Model", new[] { "materiaId" });
            DropColumn("dbo.Solicitud_Model", "materia_id");
            DropTable("dbo.Materia_ModelEstudiante_Model");
            DropTable("dbo.estudianteMateria_Model");
            CreateIndex("dbo.Estudiante_ModelArea_Model", "Area_Model_id");
            CreateIndex("dbo.Estudiante_ModelArea_Model", "Estudiante_Model_id");
            CreateIndex("dbo.Solicitud_Model", "area_id");
            CreateIndex("dbo.estudianteArea_Model", "est_id");
            CreateIndex("dbo.estudianteArea_Model", "areaId");
            AddForeignKey("dbo.Solicitud_Model", "area_id", "dbo.Area_Model", "id");
            AddForeignKey("dbo.estudianteArea_Model", "est_id", "dbo.Estudiante_Model", "id");
            AddForeignKey("dbo.estudianteArea_Model", "areaId", "dbo.Area_Model", "id", cascadeDelete: true);
            AddForeignKey("dbo.Estudiante_ModelArea_Model", "Area_Model_id", "dbo.Area_Model", "id", cascadeDelete: true);
            AddForeignKey("dbo.Estudiante_ModelArea_Model", "Estudiante_Model_id", "dbo.Estudiante_Model", "id", cascadeDelete: true);
        }
    }
}
