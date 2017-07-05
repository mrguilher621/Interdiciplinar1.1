using Models.Tabelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interdiciplinar1._1.Models
{
    public class CategoriaListAPIModel : APIModel
    {
        // { Message: "OK", Result: [{},{}] }
        public List<Categoria> Result { get; set; }
    }

    public class CategoriaAPIModel : APIModel
    {
        // { Message: "OK", Result: {} }
        public Categoria Result { get; set; }
    }
}