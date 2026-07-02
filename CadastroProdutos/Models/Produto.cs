using System;
using System.ComponentModel.DataAnnotations;

namespace CadastroProdutos.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo nome do produto é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo nome do produto deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "O campo preço do produto deve ser maior que zero.")]
        public decimal Preco { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "O campo estoque do produto não pode ser negativo.")]
        public int Estoque { get; set; }

    }
}