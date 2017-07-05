using Models.Cadastros;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Cadastros
{
  public  class FabricanteDAL
    {
        private EFContext context = new EFContext();

        public IQueryable<Fabricante> GetNomeFabricante()
        {
            return context.Fabricantes.OrderBy(b => b.Nome);
        }

        public Fabricante GetFabricanteId(long id)
        {
            return context.Fabricantes.Where(c => c.FabricanteId == id).First();

        }

        public void GravarFabricante(Fabricante fabricante)
        {
            if (fabricante.FabricanteId == null)
            {
                context.Fabricantes.Add(fabricante);
            }
            else
            {
                context.Entry(fabricante).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Fabricante EliminarFabricanteId(long id)
        {
            Fabricante fabricante = GetFabricanteId(id);
            context.Fabricantes.Remove(fabricante);
            context.SaveChanges();
            return fabricante;
        }
    }
}
