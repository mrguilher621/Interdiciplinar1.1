using Models.Cadastros;
using Servico.Cadastros;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Interdiciplinar1._1.Controllers
{
    public class FabricantesController : Controller
    {
        #region [Metodos]
        private FabricanteServico fabricanteServico = new FabricanteServico();

        private ActionResult GetViewFabricanteId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricante fabricante = fabricanteServico.GetFabricanteId((long)id);
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }

        private void PopularViewBag(Fabricante fabricante = null)
        {
            if (fabricante == null)
            {
                ViewBag.FabricanteId = new SelectList(fabricanteServico.GetNomeFabricante(), "FabricanteId", "Nome");

            }
            else
            {
                ViewBag.FabricanteId = new SelectList(fabricanteServico.GetNomeFabricante(), "CategoriaId", "Nome", fabricante.FabricanteId);

            }
        }

        private ActionResult GravarFabricante(Fabricante fabricante)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    fabricanteServico.GravarFabricante(fabricante);
                    return RedirectToAction("Index");
                }
                return View(fabricante);
            }
            catch
            {
                return View(fabricante);
            }
        }

        #endregion [Metodos]
        // GET: Fabricantes
        public ActionResult Index()
        {
            return View(fabricanteServico.GetNomeFabricante());
        }

        public ActionResult Create()
        {
            PopularViewBag();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fabricante fabricante)
        {
            return GravarFabricante(fabricante);
        }

        public ActionResult Edit(long? id)
        {
            PopularViewBag(fabricanteServico.GetFabricanteId((long)id));

            return GetViewFabricanteId(id);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fabricante fabricante)
        {
            
            return GravarFabricante(fabricante);
        }

        public ActionResult Details(long? id)
        {
           

            return GetViewFabricanteId(id);
        }

        public ActionResult Delete(long? id)
        {
            return GetViewFabricanteId(id);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Fabricante fabricante = fabricanteServico.EliminarFabricanteId(id);
           
            TempData["Message"] = "Fabricante" + fabricante.Nome.ToUpper() + "Foi Removido";
            return RedirectToAction("Index");
        }
    }
}