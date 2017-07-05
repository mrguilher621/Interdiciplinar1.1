using Models.Tabelas;
using Persistencia.DAL.Tabelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico.Tabelas
{
  public  class CategoriaServico
    {
        private CategoriaDAL categoriaDAL = new CategoriaDAL();

        public IQueryable<Categoria> GetCategoria()
        {
            return categoriaDAL.GetCategoria();
        }

        public IQueryable<Categoria> GetNomeCategoria()
        {
            return categoriaDAL.GetNameCategoria();
        }

        public Categoria GetCategoriaId(long id)
        {
            return categoriaDAL.GetCategoriaId(id);
        }

        public void GravarCategoria(Categoria categoria)
        {
            categoriaDAL.GravarCategoria(categoria);
        }

        public Categoria EliminarCategoriaId(long id)
        {
            return categoriaDAL.EliminarCategoriaId(id);
        }


    }
}
