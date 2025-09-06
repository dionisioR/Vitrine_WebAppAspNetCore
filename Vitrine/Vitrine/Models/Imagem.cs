using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vitrine.Models {

    [Table("imagens")]
    public class Imagem {
        [Key]
        public int ImagemId { get; set; }
        
        [Required, StringLength(180)]
        public string Nome { get; set; }

        [NotMapped]
        public IFormFile? ArquivoImagem { get; set; } // Usado apenas para upload no formulário 

        [ForeignKey("Produto")]
        public int ProdutoId { get; set; } // FK
        public Produto? Produto { get; set; } // Navegação para Produto

        // Método auxiliar para gerar nome único com base em timestamp
        public static string GerarNomeArquivo(string nomeOriginal) {
            var extensao = Path.GetExtension(nomeOriginal);
            var timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            return $"{timestamp}{extensao}";
        }

    }
}
