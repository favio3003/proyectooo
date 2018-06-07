namespace Proyecto1._1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class loquesea : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Estudiante_Model", "correoelectronico");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Estudiante_Model", "correoelectronico", c => c.String());
        }
    }
}
