using Models.Tabelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Models.Cadastros
{
    [KnownType(typeof(Categoria))]
    [KnownType(typeof(Fabricante))]
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