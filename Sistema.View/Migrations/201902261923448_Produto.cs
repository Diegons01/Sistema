namespace Sistema.View.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Produto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 50),
                        Descricao = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 255),
                        Descricao = c.String(maxLength: 255),
                        Quatidade = c.Int(nullable: false),
                        Placa = c.String(maxLength: 255),
                        DataFabricacao = c.DateTime(nullable: false),
                        Preco = c.Double(nullable: false),
                        CorId = c.Int(nullable: false),
                        Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cors", t => t.CorId, cascadeDelete: true)
                .Index(t => t.CorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtoes", "CorId", "dbo.Cors");
            DropIndex("dbo.Produtoes", new[] { "CorId" });
            DropTable("dbo.Produtoes");
            DropTable("dbo.Cors");
        }
    }
}
