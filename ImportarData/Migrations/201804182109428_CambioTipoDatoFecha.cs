namespace ImportarData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambioTipoDatoFecha : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Encargos", "fecha", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Encargos", "fecha", c => c.DateTime(nullable: false));
        }
    }
}
