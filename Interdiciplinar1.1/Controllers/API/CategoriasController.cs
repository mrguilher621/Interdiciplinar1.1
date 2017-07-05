using Interdiciplinar1._1.Models;
using Models.Tabelas;
using Servico.Cadastros;
using Servico.Tabelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Interdiciplinar1._1.Controllers.API
{
    public class CategoriasController : ApiController
    {
        private CategoriaServico servico = new CategoriaServico();
        private ModeloServico modeloServico = new ModeloServico();
        // GET api/Categorias
        public CategoriaListAPIModel GetCategoria()
        {
            var apiModel = new CategoriaListAPIModel();
            try
            {
                apiModel.Result = servico.GetCategoria().ToList();
            }
            catch(Exception )
            {
                apiModel.Message = "!OK";
            }
            return apiModel;
        }
        


        // GET api/<controller>/5
        public CategoriaAPIModel Get(long? id)
        {
            var apiModel = new CategoriaAPIModel();

            try
            {
                if (id == null)
                    apiModel.Message = "!OK";
                else
                {
                    apiModel.Result = servico.GetCategoriaId(id.Value);
                    if (apiModel.Result != null)
                        apiModel.Result.Modelo = modeloServico
                            .GetByCategoria(id.Value).ToList();
                }
            }
            catch (System.Exception)
            {
                apiModel.Message = "!OK";
            }

            return apiModel;
        }

        // POST api/<controller>
        public void Post([FromBody]Categoria value)
        {
            servico.GravarCategoria(value);
        }

        // PUT api/<controller>/5
        public void Put(long id, [FromBody]Categoria value)
        {
            servico.GravarCategoria(value);
        }

        // DELETE api/<controller>/5
        public void Delete(long id)
        {
            servico.EliminarCategoriaId(id);
        }
    }
}