using Models.Cadastros;
using Persistencia.DAL.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico.Cadastros
{
   public class FabricanteServico
    {
        private FabricanteDAL fabricanteDAL = new FabricanteDAL();

        public IQueryable<Fabricante> GetNomeFabricante()
        {
            return fabricanteDAL.GetNomeFabricante();
        }

        public Fabricante GetFabricanteId(long id)
        {
            return fabricanteDAL.GetFabricanteId(id);
        }

        public void GravarFabricante(Fabricante fabricante)
        {
            fabricanteDAL.GravarFabricante(fabricante);
        }

        public Fabricante EliminarFabricanteId(long id)
        {
            return fabricanteDAL.EliminarFabricanteId(id);
        }
    }
}
