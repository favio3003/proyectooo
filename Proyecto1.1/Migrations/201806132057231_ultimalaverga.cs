namespace Proyecto1._1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ultimalaverga : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Estudiante_Model", "Materiaid", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Estudiante_Model", "Materiaid");
        }
    }
}
