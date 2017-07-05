using Models.Cadastros;
using Servico.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Interdiciplinar1._1.Controllers.API
{
    public class FabricantesController : ApiController
    {
        private FabricanteServico servico = new FabricanteServico();
        // GET api/<controller>
        public IEnumerable<Fabricante> Get()
        {
            return servico.GetFabricante();
        }
        // GET api/<controller>/5
        public Fabricante Get(long? id)
        {
                if (id == null) return null;

                return servico.GetFabricanteId(id.Value);
        }

        // POST api/<controller>
        public void Post([FromBody]Fabricante value)
        {
            servico.GravarFabricante(value);
        }

        // PUT api/<controller>/5
        public void Put(long id, [FromBody]Fabricante value)
        {
            servico.GravarFabricante(value);
        }

        // DELETE api/<controller>/5
        public void Delete(long id)
        {
            servico.EliminarFabricanteId(id);
        }
    }
}