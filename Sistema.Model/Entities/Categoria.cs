using System.ComponentModel.DataAnnotations;

namespace Sistema.Model.Entities
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        public string Nome { get; set; }     

        public override string ToString()
        {
            return Nome;
        }
    }
}
