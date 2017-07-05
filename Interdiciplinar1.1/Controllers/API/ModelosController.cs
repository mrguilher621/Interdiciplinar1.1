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
    public class ModelosController : ApiController
    {
        private ModeloServico servico = new ModeloServico();
        // GET api/<controller>
        public IEnumerable<Modelo> Get()
        {
            return servico.GetModelo();
        }

        // GET api/<controller>/5
        public Modelo Get(long? id)
        {
            if (id == null) return null;
            return servico.GetModeloId(id.Value);
        }

        // POST api/<controller>
        public void Post([FromBody]Modelo value)
        {
            servico.GravarModelo(value);
        }

        // PUT api/<controller>/5
        public void Put(long id, [FromBody]Modelo value)
        {
            servico.GravarModelo(value);
        }

        // DELETE api/<controller>/5
        public void Delete(long id)
        {
            servico.EliminarModeloId(id);
        }
    }
}