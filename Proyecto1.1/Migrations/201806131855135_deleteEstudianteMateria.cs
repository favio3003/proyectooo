namespace Proyecto1._1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteEstudianteMateria : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.estudianteMateria_Model", "est_id", "dbo.Estudiante_Model");
            DropForeignKey("dbo.estudianteMateria_Model", "materiaId", "dbo.Materia_Model");
            DropIndex("dbo.estudianteMateria_Model", new[] { "materiaId" });
            DropIndex("dbo.estudianteMateria_Model", new[] { "est_id" });
            AddColumn("dbo.Estudiante_Model", "comentario", c => c.String());
            DropTable("dbo.estudianteMateria_Model");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => new { t.estudianteId, t.materiaId });
            
            DropColumn("dbo.Estudiante_Model", "comentario");
            CreateIndex("dbo.estudianteMateria_Model", "est_id");
            CreateIndex("dbo.estudianteMateria_Model", "materiaId");
            AddForeignKey("dbo.estudianteMateria_Model", "materiaId", "dbo.Materia_Model", "id", cascadeDelete: true);
            AddForeignKey("dbo.estudianteMateria_Model", "est_id", "dbo.Estudiante_Model", "id");
        }
    }
}
