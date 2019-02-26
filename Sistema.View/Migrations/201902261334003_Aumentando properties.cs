namespace Sistema.View.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Aumentandoproperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vendedors", "Estado", c => c.String(maxLength: 255));
            AddColumn("dbo.Vendedors", "DataNascimento", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vendedors", "DataNascimento");
            DropColumn("dbo.Vendedors", "Estado");
        }
    }
}
