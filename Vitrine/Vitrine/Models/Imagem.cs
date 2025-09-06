using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vitrine.Models {

    [Table("imagens")]
    public class Imagem {
        [Key]
        public int ImagemId { get; set; }
        
        public string? Nome { get; set; }

        // Usado apenas no upload, não vai para o banco
        [NotMapped]
        [Display(Name = "Selecionar Imagem")]
        public IFormFile? ArquivoImagem { get; set; } // Usado apenas para upload no formulário 

        [ForeignKey("Produto")]
        [Required(ErrorMessage = "O  código do produto é obrigatório")]
        public int ProdutoId { get; set; } // FK
        public Produto? Produto { get; set; } // Navegação para Produto


    }
}
