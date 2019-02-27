using System;
using System.ComponentModel.DataAnnotations;
using Sistema.Model.Entities.Enums;

namespace Sistema.Model.Entities
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        public string Nome { get; set; }
        [StringLength(255)]
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        [StringLength(255)]
        public string Placa { get; set; }
        public Cor Cor { get; set; }
        public int CorId { get; set; }
        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }
        public EnumAcessorio Acessorio { get; set; }        
        public double Preco { get; set; }
        public int Km { get; set; } 
        public DateTime DataFabricacao { get; set; }
    }
}
