
using Interdiciplinar1._1.Models;
using Models.Tabelas;
using Newtonsoft.Json;
using Servico.Tabelas;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Interdiciplinar1._1.Controllers
{
    public class CategoriasController : Controller
    {
        #region [Metodos]
        private CategoriaServico categoriaServico = new CategoriaServico();

        private async Task<ActionResult> GetViewCategoriaId(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            CategoriaAPIModel item = null;
            var resp = await GetFromAPI(response =>
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content
                    .ReadAsStringAsync().Result;
                    item = JsonConvert
                    .DeserializeObject<CategoriaAPIModel>(result);
                }
            }, id.Value);

            if (!resp.IsSuccessStatusCode)
                return new HttpStatusCodeResult(resp.StatusCode);

            if (item.Message == "!OK" ||
                item.Result == null) return HttpNotFound();

            return View(item.Result);
        }

        private async Task<HttpResponseMessage> GetFromAPI(
           Action<HttpResponseMessage> action,
           long? id = null)
        {
            using (var client = new HttpClient())
            {
                var reqUrl = HttpContext.Request.Url;
                var baseUrl = string.Format("{0}://{1}",
                    reqUrl.Scheme, reqUrl.Authority);
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();

                var url = "Api/Categorias";
                if (id != null) url += "/" + id;

                var request = await client.GetAsync(url);
                //HttpContent content = new HttpContent();
                ////content.
                //var r = client.PostAsync(url, content);

                if (action != null)
                    action.Invoke(request);

                return request;
            }
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
        public async Task<ActionResult> Index()
        {
            var apiModel = new CategoriaListAPIModel();

            var resp = await GetFromAPI(response =>
            {
                if (response.IsSuccessStatusCode)
                {
                    // { Message: "OK", Result: [{},{}]}
                    string result = response.Content
                    .ReadAsStringAsync().Result;
                    apiModel = JsonConvert
                    .DeserializeObject<CategoriaListAPIModel>(result);
                }
            });

            return View(apiModel.Result);
        }

        // GET: Categorias/Details/5
        public async Task<ActionResult> Details(long? id)
        {
           

            return await GetViewCategoriaId(id);
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
        public async Task<ActionResult> Edit(long? id)
        {

            PopularViewBag(categoriaServico.GetCategoriaId((long)id));

            return await GetViewCategoriaId(id);
        }

        // POST: Categorias/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
           
            return GravarCategoria(categoria);

        }

        // GET: Categorias/Delete/5
        public async  Task<ActionResult> Delete(long? id)
        {
            return await GetViewCategoriaId(id);
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
