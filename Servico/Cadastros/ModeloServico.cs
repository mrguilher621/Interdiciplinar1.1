using Models.Cadastros;
using Persistencia.DAL.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico.Cadastros
{
   public class ModeloServico
    {
        private ModeloDAL modeloDAL = new ModeloDAL();

        public IQueryable<Modelo> GetModelo()
        {
            return modeloDAL.GetModelo();
        }

        public IQueryable GetNomeModelo()
        {
            return modeloDAL.GetNomeModelo();
        }

        public Modelo GetModeloId(long id)
        {
            return modeloDAL.GetModeloId(id);
        }

        public void GravarModelo(Modelo modelo)
        {
            modeloDAL.GravarModelo(modelo);
        }

        public Modelo EliminarModeloId(long id)
        {
            return modeloDAL.EliminarModeloId(id);
        }

        public IEnumerable<Modelo>GetByCategoria(long categoriaId)
        {
            return modeloDAL.GetByCategoria(categoriaId);
        }

        public IEnumerable<Modelo> GetByFabricante(long fabricanteId)
        {
            return modeloDAL.GetByFabricante(fabricanteId);
        }
    }
}
