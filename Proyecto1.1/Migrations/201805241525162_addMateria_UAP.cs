namespace Proyecto1._1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMateria_UAP : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Materia_Model",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.unidadDeAprendizaje_Model",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        idMateria_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Materia_Model", t => t.idMateria_id)
                .Index(t => t.idMateria_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.unidadDeAprendizaje_Model", "idMateria_id", "dbo.Materia_Model");
            DropIndex("dbo.unidadDeAprendizaje_Model", new[] { "idMateria_id" });
            DropTable("dbo.unidadDeAprendizaje_Model");
            DropTable("dbo.Materia_Model");
        }
    }
}
