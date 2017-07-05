using Interdiciplinar1._1.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Interdiciplinar1._1.Models;
using System.Net;

namespace Interdiciplinar1._1.Controllers
{
    public class ModelosController : Controller
    {
        private EFContext context = new EFContext();
        // GET: Modelos
        public ActionResult Index()
        {
            var modelos = context.Modelos.Include(c => c.Categoria).Include(f => f.Fabricante).OrderBy(n => n.Nome);
            return View(modelos);
        }

        // GET: Modelos/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modelo modelo = context.Modelos.Where(m=>m.ModeloId == id).
                Include(c=>c.Categoria).Include(f=>f.Fabricante).First();
            if (modelo == null)
            {
                return HttpNotFound();
            }
            return View(modelo);
        }

        // GET: Modelos/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(context.Categorias.OrderBy(b => b.Nome), "CategoriaId", "Nome");
            ViewBag.FabricanteId = new SelectList(context.Fabricantes.OrderBy(b => b.Nome), "FabricanteId", "Nome");
            return View();
        }

        // POST: Modelos/Create
        [HttpPost]
        public ActionResult Create(Modelo  modelo)
        {
            try
            {
                context.Modelos.Add(modelo);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(modelo);
            }
        }

        // GET: Modelos/Edit/5
        public ActionResult Edit(long? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modelo modelo = context.Modelos.Find(id);
            if(modelo == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaId = new SelectList(context.Categorias.OrderBy(b => b.Nome), "CategoriaId", "Nome",modelo.CategoriaId);
            ViewBag.FabricanteId = new SelectList(context.Fabricantes.OrderBy(b => b.Nome), "FabricanteId", "Nome",modelo.FabricanteId);
            return View(modelo);
        }

        // POST: Modelos/Edit/5
        [HttpPost]
        public ActionResult Edit(Modelo modelo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Entry(modelo).State = EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(modelo);
            }
            catch
            {
                return View(modelo);
            }
        }

        // GET: Modelos/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modelo modelo = context.Modelos.Where(m => m.ModeloId == id).
                Include(c => c.Categoria).Include(f => f.Fabricante).First();
            if (modelo == null)
            {
                return HttpNotFound();
            }
            return View(modelo);
        }

        // POST: Modelos/Delete/5
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                Modelo modelo = context.Modelos.Find(id);
                context.Modelos.Remove(modelo);
                context.SaveChanges();
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
