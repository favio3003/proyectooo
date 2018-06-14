namespace Proyecto1._1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class l : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comentario_Model",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        comentario = c.String(),
                        estudiante_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Estudiante_Model", t => t.estudiante_id)
                .Index(t => t.estudiante_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comentario_Model", "estudiante_id", "dbo.Estudiante_Model");
            DropIndex("dbo.Comentario_Model", new[] { "estudiante_id" });
            DropTable("dbo.Comentario_Model");
        }
    }
}
