namespace Dados.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vendedor")]
    public partial class Vendedor
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Nome { get; set; }

        public string Email { get; set; }

        public int Telefone { get; set; }

        public double Salario { get; set; }
    }
}
