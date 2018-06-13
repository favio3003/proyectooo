namespace Proyecto1._1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addComentarioInEstudianteArea : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.estudianteArea_Model", "comentario", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.estudianteArea_Model", "comentario");
        }
    }
}
