using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using API_Monitoramento.Models;

namespace API_Monitoramento
{
    public class dbContext : DbContext
    {
        //CLASSES
        public DbSet<Usuario> usuario { get; set; }
        public DbSet<Veiculo> veiculo { get; set; }
        public DbSet<ResumoUltimaViagem> resumoUltimaViagem { get; set; }

        public dbContext(DbContextOptions<dbContext> options) : base(options) { }
        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<dbContext>
        {
            public dbContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var builder = new DbContextOptionsBuilder<dbContext>();
                var connectionString = configuration.GetConnectionString("DefaultConecction");
                builder.UseSqlServer(connectionString);
                return new dbContext(builder.Options);
            }
        }
    }
}
