using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace CrowdFunding.Infrastructure.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            // Construye la configuración para encontrar el appsettings.json del proyecto API
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Obtiene la cadena de conexión
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Crea las opciones de DbContext
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseSqlServer(connectionString);

            return new AppDbContext(builder.Options);
        }
    }
}