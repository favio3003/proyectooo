namespace Proyecto1._1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createPasanteTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pasante_Model",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        telefono = c.String(),
                        descripcion = c.String(),
                        imagen = c.String(),
                        horario = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pasante_Model");
        }
    }
}
