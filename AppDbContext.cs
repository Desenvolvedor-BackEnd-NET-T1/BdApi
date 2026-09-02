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

    }

}