using System.ComponentModel.DataAnnotations;

namespace Sistema.Model.Entities
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [StringLength(30)]
        public string Nome { get; set; }
    }
}
