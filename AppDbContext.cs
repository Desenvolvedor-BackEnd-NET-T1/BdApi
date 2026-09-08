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
        public DbSet<Funcionario> Funcionarios => Set<Funcionario>();

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

                cliente.Property(c => c.Ativo)
                        .HasColumnName("ativoCli");
            });


            modelBuilder.Entity<Funcionario>(funcionario =>
            {
                funcionario.ToTable("tb_funcionarios");

                funcionario.HasKey(f => f.Id);

                funcionario.Property( f => f.Id)
                           .HasColumnName("idFunc")
                           .HasColumnType("varchar(50)");

                funcionario.Property(f => f.Nome)
                           .HasColumnName("nomeFunc")
                           .HasColumnType("varchar(100)");
                
                funcionario.Property(d => d.Email)
                           .HasColumnName("emailFunc")
                           .HasColumnType("varchar(100)");
            });
        }

    }

}