namespace Sistema.View.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MelhoradoPropertiesProduto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produtoes", "CategoriaId", c => c.Int(nullable: false));
            AddColumn("dbo.Produtoes", "Acessorio", c => c.Int(nullable: false));
            AddColumn("dbo.Produtoes", "Km", c => c.Int(nullable: false));
            CreateIndex("dbo.Produtoes", "CategoriaId");
            AddForeignKey("dbo.Produtoes", "CategoriaId", "dbo.Categorias", "Id", cascadeDelete: true);
            DropColumn("dbo.Produtoes", "Estado");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produtoes", "Estado", c => c.Int(nullable: false));
            DropForeignKey("dbo.Produtoes", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Produtoes", new[] { "CategoriaId" });
            DropColumn("dbo.Produtoes", "Km");
            DropColumn("dbo.Produtoes", "Acessorio");
            DropColumn("dbo.Produtoes", "CategoriaId");
        }
    }
}
