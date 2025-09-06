// Importa o namespace onde está definida a classe Cadastro
using Microsoft.EntityFrameworkCore;
using Vitrine.Models;

namespace Vitrine.Data {
    public class AppDbContext : DbContext {

        // Construtor que recebe as opções de configuração do contexto
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Define as tabelas  no banco de dados, representada pela entidade Usuario, Produto e Imagem
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Imagem> Imagens { get; set; }
    }
}
