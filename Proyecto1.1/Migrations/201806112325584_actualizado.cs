namespace Proyecto1._1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class actualizado : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Estudiante_Model", "Registerid", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Estudiante_Model", "Registerid");
        }
    }
}
