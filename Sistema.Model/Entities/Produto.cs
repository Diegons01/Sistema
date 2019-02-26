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
        public int Quatidade { get; set; }
        [StringLength(255)]
        public string Placa { get; set; }
        public DateTime DataFabricacao { get; set; }
        public double Preco { get; set; }
        public Cor Cor { get; set; }
        public int CorId { get; set; }
        public Estado Estado { get; set; }
    }
}
