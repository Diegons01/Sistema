using Sistema.Model.Entities;

namespace Dados.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model2019 : DbContext
    {
        public Model2019()
            : base("name=SQL")
        {
        }

        public DbSet<Vendedor> Vendedor { get; set; }
        public DbSet<Categoria> Categoria { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
