﻿using Persistencia.Contexts;
using System.Linq;
using System.Data.Entity;
using Models.Cadastros;

namespace Persistencia.DAL.Cadastros
{
    public class ModeloDAL
    {
        private EFContext context = new EFContext();

        public IQueryable<Modelo> GetModelo()
        {
            return context.Modelos;
        }

        public IQueryable GetNomeModelo()
        {
            return context.Modelos.Include(c => c.Categoria).Include(f => f.Fabricante).OrderBy(n => n.Nome);
        }

        public Modelo GetModeloId(long id)
        {
            return context.Modelos.Where(m => m.ModeloId == id).
                Include(c => c.Categoria).Include(f => f.Fabricante).First();
        }

        public void GravarModelo(Modelo modelo)
        {
            if(modelo.ModeloId == null)
            {
                context.Modelos.Add(modelo);
            }
            else
            {
                context.Entry(modelo).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Modelo EliminarModeloId(long id)
        {
            Modelo modelo = GetModeloId(id);
            context.Modelos.Remove(modelo);
            context.SaveChanges();
            return modelo;
        }

        public IQueryable<Modelo>GetByCategoria(long categoriaId)
        {
            return context.Modelos.Where(m => m.CategoriaId.HasValue && m.CategoriaId.Value == categoriaId)
                .Include(f => f.Fabricante);
        }

        public IQueryable<Modelo> GetByFabricante(long fabricanteId)
        {
            return context.Modelos.Where(m => m.CategoriaId.HasValue && m.FabricanteId.Value == fabricanteId)
                .Include(f => f.Fabricante);
        }
    }
}
