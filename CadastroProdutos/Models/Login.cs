using System;
using System.ComponentModel.DataAnnotations;

namespace CadastroProdutos.Models
{
    public class Login
    {
        [Required(ErrorMessage = "O campo usuário é obrigatório.")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "O campo senha é obrigatório.")]
        public string Senha { get; set; }
    }
}