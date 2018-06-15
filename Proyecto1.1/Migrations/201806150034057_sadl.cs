namespace Proyecto1._1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sadl : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Estudiante_Model", "telefono", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Estudiante_Model", "telefono", c => c.String(nullable: false));
        }
    }
}
