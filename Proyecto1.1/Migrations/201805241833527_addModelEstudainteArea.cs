namespace Proyecto1._1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addModelEstudainteArea : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Estudiante_ModelArea_Model",
                c => new
                    {
                        Estudiante_Model_id = c.Int(nullable: false),
                        Area_Model_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Estudiante_Model_id, t.Area_Model_id })
                .ForeignKey("dbo.Estudiante_Model", t => t.Estudiante_Model_id, cascadeDelete: true)
                .ForeignKey("dbo.Area_Model", t => t.Area_Model_id, cascadeDelete: true)
                .Index(t => t.Estudiante_Model_id)
                .Index(t => t.Area_Model_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Estudiante_ModelArea_Model", "Area_Model_id", "dbo.Area_Model");
            DropForeignKey("dbo.Estudiante_ModelArea_Model", "Estudiante_Model_id", "dbo.Estudiante_Model");
            DropIndex("dbo.Estudiante_ModelArea_Model", new[] { "Area_Model_id" });
            DropIndex("dbo.Estudiante_ModelArea_Model", new[] { "Estudiante_Model_id" });
            DropTable("dbo.Estudiante_ModelArea_Model");
        }
    }
}
