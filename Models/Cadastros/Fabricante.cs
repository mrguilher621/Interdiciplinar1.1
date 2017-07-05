using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models.Cadastros
{
    public class Fabricante
    {
        public long? FabricanteId { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Modelo> Modelo { get; set; }
    }
}