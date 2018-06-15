namespace Proyecto1._1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sad4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Solicitud_Model", "telefono");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Solicitud_Model", "telefono", c => c.String(nullable: false));
        }
    }
}
