using Microsoft.AspNetCore.Mvc;
using Vitrine.Data;
using Vitrine.Models;

namespace Vitrine.Controllers {
    public class UsuarioController : Controller {

        //-----------------------------------------------
        private readonly AppDbContext _context;
              
        // Injeção de dependência do DbContext
        public UsuarioController(AppDbContext context) {
            _context = context;
        }

        //-----------------------------------------------
        // GET: Exibe formulário de cadastro
        public IActionResult Index() {
            return View();
        }

        //-----------------------------------------------
        // CadastrarUsuario - Vai inserir os dados do usuario na base de dados
        // POST: Recebe dados do formulário e salva no banco
        [HttpPost]
        // Protege contra envios falsos de formulário (segurança). O Razor coloca um token oculto no form.
        [ValidateAntiForgeryToken]
        public IActionResult CadastrarUsuario(Usuario usuario) {

            // Verifica se os dados estão válidos (campos obrigatórios, formatos, etc.).
            if (ModelState.IsValid) {
                usuario.Senha = Criptografia.Criptografar(usuario.Senha);
                // Pede ao Entity Framework para adicionar esse usuário no banco (ainda não grava de verdade).
                _context.Usuarios.Add(usuario);

                // Agora sim grava no banco de dados.
                _context.SaveChanges();

                // Depois de salvar, envia o usuário para a página de confirmação.
                return RedirectToAction("Sucesso");
            }

            // Se os dados forem inválidos, volta para o formulário mostrando os erros.
            return View(usuario);
        }

        //-----------------------------------------------
        // Página simples de confirmação
        public IActionResult Sucesso() {
            return View();
        }
    }

}

