using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Model.Entities
{
    public class Cor
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Nome { get; set; }
        [StringLength(255)]
        public string Descricao { get; set; }
        public List<Produto> Produto { get; set; } = new List<Produto>();

        public override string ToString()
        {
            return Nome;
        }
    }
}
