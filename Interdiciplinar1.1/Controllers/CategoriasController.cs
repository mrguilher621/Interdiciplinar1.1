
using Models.Tabelas;
using Servico.Tabelas;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Interdiciplinar1._1.Controllers
{
    public class CategoriasController : Controller
    {
        #region [Metodos]
        private CategoriaServico categoriaServico = new CategoriaServico();

        private ActionResult GetViewCategoriaId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = categoriaServico.GetCategoriaId((long)id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        private void PopularViewBag(Categoria categoria = null)
        {
            if (categoria == null)
            {
                ViewBag.CategoriaId = new SelectList(categoriaServico.GetNomeCategoria(), "CategoriaId", "Nome");
               
            }
            else
            {
                ViewBag.CategoriaId = new SelectList(categoriaServico.GetNomeCategoria(), "CategoriaId", "Nome", categoria.CategoriaId);
                
            }
        }

        private ActionResult GravarCategoria(Categoria categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    categoriaServico.GravarCategoria(categoria);
                    return RedirectToAction("Index");
                }
                return View(categoria);
            }
            catch
            {
                return View(categoria);
            }
        }

        #endregion [Metodos]
        // GET: Categorias
        public ActionResult Index()
        {
            return View(categoriaServico.GetNomeCategoria());
        }

        // GET: Categorias/Details/5
        public ActionResult Details(long? id)
        {
           

            return GetViewCategoriaId(id);
        }

        // GET: Categorias/Create
        public ActionResult Create()
        {
            PopularViewBag();
            return View();
        }

        // POST: Categorias/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            
            return GravarCategoria(categoria);

        }

        // GET: Categorias/Edit/5
        public ActionResult Edit(long? id)
        {

            PopularViewBag(categoriaServico.GetCategoriaId((long)id));

            return GetViewCategoriaId(id);
        }

        // POST: Categorias/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
           
            return GravarCategoria(categoria);

        }

        // GET: Categorias/Delete/5
        public ActionResult Delete(long? id)
        {
            return GetViewCategoriaId(id);
        }

        // POST: Categorias/Delete/5
        [HttpPost]
        public ActionResult Delete(long id)
        {
            Categoria categoria = categoriaServico.EliminarCategoriaId(id);
            TempData["Message"] = "Categoria" + categoria.Nome.ToUpper() + "Foi Removido";
            return RedirectToAction("Index");
        }
    }
}
