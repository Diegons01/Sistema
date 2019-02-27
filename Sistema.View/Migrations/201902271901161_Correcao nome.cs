namespace Sistema.View.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Correcaonome : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produtoes", "Quantidade", c => c.Int(nullable: false));
            DropColumn("dbo.Produtoes", "Quatidade");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produtoes", "Quatidade", c => c.Int(nullable: false));
            DropColumn("dbo.Produtoes", "Quantidade");
        }
    }
}
