using System.ComponentModel.DataAnnotations;

namespace Entity.API.ViewModels
{
    public class ClienteInserirViewModel
    {
        [Required (ErrorMessage = "O nome do cliente é obrigatório")]
        [MaxLength (150, ErrorMessage = "O tamanho máximo do nome do cliente é 150")]
        public string   Nome { get; set; }
        [Required(ErrorMessage = "O e-mail do cliente é obrigatório")]
        [EmailAddress(ErrorMessage = "O e-mail do cliente é inválido.")]
        [MaxLength(100, ErrorMessage = "O tamanho máximo do e-mail do cliente é 100")]
        public string   Email { get; set; }
        [Required(ErrorMessage = "A data de nascimento do cliente é obrigatório")]
        public DateTime DataNascimento { get; set; }
    }
}
