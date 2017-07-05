using Interdiciplinar1._1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Interdiciplinar1._1.Contexts
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Banco")
        {
            Database.SetInitializer<EFContext>(new DropCreateDatabaseIfModelChanges<EFContext>());
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }

        public DbSet<Modelo> Modelos { get; set; }

    }
}
