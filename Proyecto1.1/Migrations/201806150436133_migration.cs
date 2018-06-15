namespace Proyecto1._1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comentario_Model", "estudiante_id", "dbo.Estudiante_Model");
            DropIndex("dbo.Comentario_Model", new[] { "estudiante_id" });
            DropColumn("dbo.Comentario_Model", "estudiante_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comentario_Model", "estudiante_id", c => c.Int());
            CreateIndex("dbo.Comentario_Model", "estudiante_id");
            AddForeignKey("dbo.Comentario_Model", "estudiante_id", "dbo.Estudiante_Model", "id");
        }
    }
}
