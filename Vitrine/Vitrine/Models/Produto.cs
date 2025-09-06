using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vitrine.Models {

    [Table("produtos")]
    public class Produto {
        [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage ="O campo nome é obrigatório")]
        [StringLength(180, MinimumLength =3, ErrorMessage ="O nome deve ter entre 3 e 180 caracteres")]
        [Display(Name ="Nome do produto:")]
        public string Nome { get; set; }

        [Display(Name ="Descrição do produto:")]
        public string? Descricao { get; set; }

        [Column(TypeName ="decimal(10,2)")]
        [Display(Name ="Preço do produto:")]
        public decimal? Preco { get; set; }

        [Display(Name="Produto ativo:")]
        public bool Ativo { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }  // FK
        public Usuario? Usuario { get; set; } // Navegação para Usuário

        // propriedade de navegação - Possui uma coleção de Imagens
        public ICollection<Imagem> Imagens { get; set; } = new List<Imagem>();
    }
}
