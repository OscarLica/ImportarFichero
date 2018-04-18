namespace ImportarData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Intialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Encargos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        albaran = c.String(maxLength: 10),
                        destinatario = c.String(maxLength: 28),
                        direccion = c.String(maxLength: 250),
                        poblacion = c.String(maxLength: 10),
                        cp = c.String(maxLength: 5),
                        provincia = c.String(maxLength: 20),
                        telefono = c.String(maxLength: 10),
                        observacviones = c.String(maxLength: 500),
                        fecha = c.DateTime(nullable: false),
                        registroBuenos = c.Int(nullable: false),
                        registrosMalos = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Encargos");
        }
    }
}
