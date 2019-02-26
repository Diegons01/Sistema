namespace Sistema.View.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Juncao_tabelas_Vendedor_Categoria : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vendedors", "CategoriaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Vendedors", "CategoriaId");
            AddForeignKey("dbo.Vendedors", "CategoriaId", "dbo.Categorias", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vendedors", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Vendedors", new[] { "CategoriaId" });
            DropColumn("dbo.Vendedors", "CategoriaId");
        }
    }
}
