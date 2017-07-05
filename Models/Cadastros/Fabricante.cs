using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Models.Cadastros
{
    public class Fabricante
    {
        public long? FabricanteId { get; set; }
        public string Nome { get; set; }
        [NotMapped]
        public virtual ICollection<Modelo> Modelo { get; set; }
    }
}