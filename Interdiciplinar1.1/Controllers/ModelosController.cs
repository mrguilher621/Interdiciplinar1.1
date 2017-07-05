using Models.Cadastros;
using Servico.Cadastros;
using Servico.Tabelas;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Interdiciplinar1._1.Controllers
{
    public class ModelosController : Controller
    {
        #region [Metodos]
        private ModeloServico modeloServico = new ModeloServico();
        private CategoriaServico categoriaServico = new CategoriaServico();
        private FabricanteServico fabricanteServico = new FabricanteServico();

        private ActionResult GetViewModeloId(long? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modelo modelo = modeloServico.GetModeloId((long)id);
            if(modelo == null)
            {
                return HttpNotFound();
            }
            return View(modelo);
        }

        private void PopularViewBag(Modelo modelo = null)
        {
            if(modelo == null)
            {
                ViewBag.CategoriaId = new SelectList(categoriaServico.GetNomeCategoria(), "CategoriaId", "Nome");
                ViewBag.FabricanteId = new SelectList(fabricanteServico.GetNomeFabricante(), "FabricanteId", "Nome");
            }
            else
            {
                ViewBag.CategoriaId = new SelectList(categoriaServico.GetNomeCategoria(), "CategoriaId", "Nome",modelo.CategoriaId);
                ViewBag.FabricanteId = new SelectList(fabricanteServico.GetNomeFabricante(), "FabricanteId", "Nome",modelo.FabricanteId);
            }
        }

        private ActionResult GravarModelo(Modelo modelo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    modeloServico.GravarModelo(modelo);
                    return RedirectToAction("Index");
                }
                return View(modelo);
            }
            catch
            {
                return View(modelo);
            }
        }
        #endregion [Metodos]

        // GET: Modelos
        public ActionResult Index()
        {
            
            return View(modeloServico.GetNomeModelo());
        }

        // GET: Modelos/Details/5
        public ActionResult Details(long? id)
        {
            return GetViewModeloId(id);
        }

        // GET: Modelos/Create
        public ActionResult Create()
        {
            PopularViewBag();
            return View();
        }

        // POST: Modelos/Create
        [HttpPost]
        public ActionResult Create(Modelo  modelo)
        {
            return GravarModelo(modelo);
        }

        // GET: Modelos/Edit/5
        public ActionResult Edit(long? id)
        {
            PopularViewBag(modeloServico.GetModeloId((long)id));
            return GetViewModeloId(id);
        }

        // POST: Modelos/Edit/5
        [HttpPost]
        public ActionResult Edit(Modelo modelo)
        {
            return GravarModelo(modelo);
        }

        // GET: Modelos/Delete/5
        public ActionResult Delete(long? id)
        {
            return GetViewModeloId(id);
        }

        // POST: Modelos/Delete/5
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                Modelo modelo = modeloServico.EliminarModeloId(id);
                TempData["Message"] = "Modelo" + modelo.Nome.ToUpper() + "Foi Removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
