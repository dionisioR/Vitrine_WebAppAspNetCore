using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vitrine.Models {

    [Table("usuarios")]
    public class Usuario {

        [Key]
        public int UsuarioId { get; set; }
        
        [Required(ErrorMessage ="Nome é um campo obrigatório")]
        [StringLength(180, MinimumLength = 3 , ErrorMessage ="O campo deve ter entre 3 e 180 caracteres")]
        [Display(Name = "Nome do usuário:")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "O e-mail é um campo obrigatório")]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido")]
        [Display(Name = "Seu melhor e-mail:")]
        public string  Email { get; set; }

        [Required(ErrorMessage = "A senha é um campo obrigatório")]
        [MinLength(6, ErrorMessage ="A senha deve ter no mínimo 6 caracteres")]
        [DataType(DataType.Password)]
        [Display(Name = "Criar sua senha:")]
        public string Senha { get; set; }

        // propriedade de navegação - Possui uma coleção de Produtos
        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
    }
}
