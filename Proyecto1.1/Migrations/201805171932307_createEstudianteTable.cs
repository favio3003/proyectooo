namespace Proyecto1._1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createEstudianteTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Estudiante_model",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ci = c.String(),
                        nombre = c.String(),
                        apellido = c.String(),
                        fechadenacimiento = c.DateTime(nullable: false),
                        telefono = c.String(),
                        sexo = c.Boolean(nullable: false),
                        correoelectronico = c.String(),
                        esayudante = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Estudiante_model");
        }
    }
}
