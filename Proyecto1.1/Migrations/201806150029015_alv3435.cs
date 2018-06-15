namespace Proyecto1._1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alv3435 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Estudiante_Model", "ci", c => c.String(nullable: false));
            AlterColumn("dbo.Estudiante_Model", "nombre", c => c.String(nullable: false));
            AlterColumn("dbo.Estudiante_Model", "apellido", c => c.String(nullable: false));
            AlterColumn("dbo.Estudiante_Model", "telefono", c => c.String(nullable: false));
            AlterColumn("dbo.Estudiante_Model", "sexo", c => c.String(nullable: false));
            DropColumn("dbo.Estudiante_Model", "correoElectronico");
            DropColumn("dbo.Estudiante_Model", "comentario");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Estudiante_Model", "comentario", c => c.String());
            AddColumn("dbo.Estudiante_Model", "correoElectronico", c => c.String());
            AlterColumn("dbo.Estudiante_Model", "sexo", c => c.String());
            AlterColumn("dbo.Estudiante_Model", "telefono", c => c.String());
            AlterColumn("dbo.Estudiante_Model", "apellido", c => c.String());
            AlterColumn("dbo.Estudiante_Model", "nombre", c => c.String());
            AlterColumn("dbo.Estudiante_Model", "ci", c => c.String());
        }
    }
}
