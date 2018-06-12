namespace Proyecto1._1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class loquesea1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Solicitud_Model", "telefono", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Solicitud_Model", "telefono");
        }
    }
}
