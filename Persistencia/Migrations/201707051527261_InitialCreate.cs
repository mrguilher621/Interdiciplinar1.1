namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        CategoriaId = c.Long(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Modelo",
                c => new
                    {
                        ModeloId = c.Long(nullable: false, identity: true),
                        Nome = c.String(),
                        Preco = c.Int(nullable: false),
                        CategoriaId = c.Long(),
                        FabricanteId = c.Long(),
                    })
                .PrimaryKey(t => t.ModeloId)
                .ForeignKey("dbo.Categoria", t => t.CategoriaId)
                .ForeignKey("dbo.Fabricante", t => t.FabricanteId)
                .Index(t => t.CategoriaId)
                .Index(t => t.FabricanteId);
            
            CreateTable(
                "dbo.Fabricante",
                c => new
                    {
                        FabricanteId = c.Long(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.FabricanteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Modelo", "FabricanteId", "dbo.Fabricante");
            DropForeignKey("dbo.Modelo", "CategoriaId", "dbo.Categoria");
            DropIndex("dbo.Modelo", new[] { "FabricanteId" });
            DropIndex("dbo.Modelo", new[] { "CategoriaId" });
            DropTable("dbo.Fabricante");
            DropTable("dbo.Modelo");
            DropTable("dbo.Categoria");
        }
    }
}
