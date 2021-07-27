using Microsoft.EntityFrameworkCore;
using StockWebMVC.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockWebMVC.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Categoria> Produto { get; set; }
        public DbSet<Categoria> Usuario { get; set; }
        public DbSet<Categoria> Cliente { get; set; }
        public DbSet<Categoria> Venda { get; set; }
        public DbSet<VendaProdutos> VendaProdutos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<VendaProdutos>().HasKey(x => new { x.CodigoVenda, x.CodigoProduto });

            builder.Entity<VendaProdutos>()
                .HasOne(x => x.Venda)
                .WithMany(y => y.Produtos)
                .HasForeignKey(x => x.CodigoVenda);

            builder.Entity<VendaProdutos>()
                .HasOne(x => x.Produto)
                .WithMany(y => y.Vendas)
                .HasForeignKey(x => x.CodigoProduto);
        }
    }
}
