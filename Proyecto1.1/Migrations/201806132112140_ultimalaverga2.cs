namespace Proyecto1._1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ultimalaverga2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MateriaEstudiantes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Estudiante_Model_id = c.Int(),
                        Materia_Model_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Estudiante_Model", t => t.Estudiante_Model_id)
                .ForeignKey("dbo.Materia_Model", t => t.Materia_Model_id)
                .Index(t => t.Estudiante_Model_id)
                .Index(t => t.Materia_Model_id);
            
            DropColumn("dbo.Estudiante_Model", "Materiaid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Estudiante_Model", "Materiaid", c => c.Int(nullable: false));
            DropForeignKey("dbo.MateriaEstudiantes", "Materia_Model_id", "dbo.Materia_Model");
            DropForeignKey("dbo.MateriaEstudiantes", "Estudiante_Model_id", "dbo.Estudiante_Model");
            DropIndex("dbo.MateriaEstudiantes", new[] { "Materia_Model_id" });
            DropIndex("dbo.MateriaEstudiantes", new[] { "Estudiante_Model_id" });
            DropTable("dbo.MateriaEstudiantes");
        }
    }
}
