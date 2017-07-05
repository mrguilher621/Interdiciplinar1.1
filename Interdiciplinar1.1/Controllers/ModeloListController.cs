using Interdiciplinar1._1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Interdiciplinar1._1.Controllers
{
    public class ModeloListController : Controller
    {
        // GET: ModeloList
        public async Task<ActionResult> Index()
        {
            var result = new List<ModeloList>();
            using (var client = new HttpClient())
            {
                client.BaseAddress =
                    new Uri("http://maisaula.net.br/");

                var ret = await client.GetAsync("selectAll.json");

                if (ret.IsSuccessStatusCode)
                {
                    var str = ret.Content
                        .ReadAsStringAsync()
                        .Result;

                    result = JsonConvert
                    .DeserializeObject<List<ModeloList>>(str);
                }
            }
            return View();
        }
    }
}