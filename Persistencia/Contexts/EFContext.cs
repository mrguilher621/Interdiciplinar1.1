using Models.Cadastros;
using Models.Tabelas;
using Persistencia.Migrations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Persistencia.Contexts
{
    public class EFContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public EFContext() : base("Banco")
        {
            Database.SetInitializer<EFContext>(new MigrateDatabaseToLatestVersion<EFContext,Configuration>());
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }

        public DbSet<Modelo> Modelos { get; set; }

    }
}
