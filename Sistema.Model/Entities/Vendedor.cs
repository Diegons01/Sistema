﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Model.Entities
{
    public class Vendedor
    {
        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        public string Nome { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        [StringLength(255)]
        public string Cidade { get; set; }
        [StringLength(255)]
        public string Estado { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Telefone { get; set; }
        public double Salario { get; set; }
        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }
        
    }
}
