using Microsoft.AspNetCore.Mvc;
using Vitrine.Data;
using Vitrine.Models;

namespace Vitrine.Controllers {
    public class ProdutoController : Controller {

        //-----------------------------------------------
        private readonly AppDbContext _context;
        public ProdutoController(AppDbContext context) {
            _context = context;
        }
        //-----------------------------------------------
        // GET: Exibe formulário de cadastro
        public IActionResult Index() {
            return View();
        }

        //-----------------------------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CadastrarProduto(Produto produto) {

            if (ModelState.IsValid) {
                _context.Produtos.Add(produto);
                _context.SaveChanges();
                return RedirectToAction("Sucesso");
            }

            return View(produto);
        }
        //-----------------------------------------------
        // Página simples de confirmação
        public IActionResult Sucesso() {
            return View();
        }
    }
}
