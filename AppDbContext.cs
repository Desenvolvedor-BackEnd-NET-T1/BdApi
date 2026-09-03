using System.Data;
using DbApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DbApi
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes => Set<Cliente>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>(cliente =>
            {
                cliente.ToTable("Tb_clientes");

                cliente.HasKey( c => c.Id);

                cliente.Property(c => c.Id)
                       .HasColumnName("codCli")
                       .HasColumnType("varchar(200)");

                cliente.Property(c => c.Email)
                        .HasColumnName("email").IsRequired();

                cliente.Property( c => c.Endereco).HasColumnName("endCli").HasColumnType("varchar(200)");
            });
        }

    }

}