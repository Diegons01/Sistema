namespace Sistema.View.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Primeiro : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vendedors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 255),
                        Email = c.String(maxLength: 255),
                        Telefone = c.Int(nullable: false),
                        Salario = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vendedors");
            DropTable("dbo.Categorias");
        }
    }
}
