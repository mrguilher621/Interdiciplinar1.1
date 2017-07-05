using Models.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models.Tabelas
{
    public class Categoria
    {
        public long? CategoriaId { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Modelo> Modelo { get; set; }
    }
}