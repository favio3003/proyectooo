namespace Proyecto1._1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sad3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comentario_Model", "comentario", c => c.String(nullable: false));
            AlterColumn("dbo.Estudiante_Model", "telefono", c => c.String(nullable: false));
            AlterColumn("dbo.Estudiante_Model", "sexo", c => c.String());
            AlterColumn("dbo.Solicitud_Model", "telefono", c => c.String(nullable: false));
            AlterColumn("dbo.Solicitud_Model", "descripcion", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Solicitud_Model", "descripcion", c => c.String());
            AlterColumn("dbo.Solicitud_Model", "telefono", c => c.String());
            AlterColumn("dbo.Estudiante_Model", "sexo", c => c.String(nullable: false));
            AlterColumn("dbo.Estudiante_Model", "telefono", c => c.String());
            AlterColumn("dbo.Comentario_Model", "comentario", c => c.String());
        }
    }
}
