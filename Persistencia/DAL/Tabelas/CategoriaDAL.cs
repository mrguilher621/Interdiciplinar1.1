﻿using Models.Tabelas;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Tabelas
{
   public class CategoriaDAL
    {
        private EFContext context = new EFContext();

        public IQueryable<Categoria> GetNameCategoria()
        {
            return context.Categorias.OrderBy(b => b.Nome);
        }

        public Categoria GetCategoriaId(long id)
        {
            return context.Categorias.Where(c => c.CategoriaId == id).First();
                
        }

        public void GravarCategoria(Categoria categoria)
        {
            if (categoria.CategoriaId == null)
            {
                context.Categorias.Add(categoria);
            }
            else
            {
                context.Entry(categoria).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Categoria EliminarCategoriaId(long id)
        {
            Categoria categoria = GetCategoriaId(id);
            context.Categorias.Remove(categoria);
            context.SaveChanges();
            return categoria;
        }
    }
}
