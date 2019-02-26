namespace Sistema.View.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Campocidade : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vendedors", "Cidade", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vendedors", "Cidade");
        }
    }
}
