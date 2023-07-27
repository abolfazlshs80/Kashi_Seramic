using Pr_Signal_ir.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Pr_Signal_ir.Persistence
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppIdentityDbContext>
    {
        public AppIdentityDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<AppIdentityDbContext>();
            var connectionString = configuration.GetConnectionString("MyConnectionString");

            builder.UseSqlServer(connectionString);

            return new AppIdentityDbContext(builder.Options);
        }
    }
}
