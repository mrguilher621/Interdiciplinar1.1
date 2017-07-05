using Models.Cadastros;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Models.Tabelas
{
    public class Categoria
    {
        public long? CategoriaId { get; set; }
        public string Nome { get; set; }
        [NotMapped]
        public virtual ICollection<Modelo> Modelo { get; set; }
    }
}