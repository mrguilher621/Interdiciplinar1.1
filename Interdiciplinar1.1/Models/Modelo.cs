﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interdiciplinar1._1.Models
{
    public class Modelo
    {
        public long? ModeloId { get; set; }
        public string Nome { get; set; }
        public int Preco { get; set; }

        public long? CategoriaId { get; set; }
        public long? FabricanteId { get; set; }

        public Categoria Categoria { get; set; }
        public Fabricante Fabricante { get; set; }
    }
}