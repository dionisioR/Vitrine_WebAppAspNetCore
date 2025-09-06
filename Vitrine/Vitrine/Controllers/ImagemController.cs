using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Vitrine.Data;
using Vitrine.Models;

namespace Vitrine.Controllers {
    public class ImagemController : Controller {

        //----------------------------------------------------------
        private readonly AppDbContext _context;
        public ImagemController(AppDbContext context) {
            _context = context;
        }

        //----------------------------------------------------------
        public IActionResult Index() {
            // Carrega lista de produtos para o dropdown
            ViewBag.ProdutoId = new SelectList(_context.Produtos, "ProdutoId", "Nome");
            return View();
        }

        //----------------------------------------------------------
        // POST: Recebe a imagem do formulário e salva
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UploadImagem(Imagem imagem) {

            if (ModelState.IsValid && imagem.ArquivoImagem != null) {
                // Gera timestamp + extensão
                string extensao = Path.GetExtension(imagem.ArquivoImagem.FileName);
                string nomeArquivo = DateTime.Now.ToString("yyyyMMddHHmmssfff") + extensao;

                // Caminho completo
                string caminho = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImagensProduto", nomeArquivo);

                // Salva no diretório
                using (var stream = new FileStream(caminho, FileMode.Create)) {
                    imagem.ArquivoImagem.CopyTo(stream);
                }

                // Grava apenas o nome no banco
                imagem.Nome = nomeArquivo;

                _context.Imagens.Add(imagem);
                _context.SaveChanges();

                return RedirectToAction("Sucesso");
            }

            // Se der erro, recarrega lista de produtos e volta pra view
            ViewBag.ProdutoId = new SelectList(_context.Produtos, "ProdutoId", "Nome", imagem.ProdutoId);
            return View("Index", imagem);

        }

        //----------------------------------------------------------
        // Página simples de confirmação
        public IActionResult Sucesso() {
            return View();
        }
    }
}
