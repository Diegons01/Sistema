using System.ComponentModel.DataAnnotations;

namespace Sistema.Model.Entities
{
    public class Endereco
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Rua { get; set; }
        public int Numero { get; set; }
        [StringLength(50)]
        public string Cidade { get; set; }
        [StringLength(10)]
        public string CEP { get; set; }

    }
}
