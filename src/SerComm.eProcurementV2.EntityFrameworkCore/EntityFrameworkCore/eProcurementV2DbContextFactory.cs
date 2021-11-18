using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SerComm.eProcurementV2.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class eProcurementV2DbContextFactory : IDesignTimeDbContextFactory<eProcurementV2DbContext>
    {
        public eProcurementV2DbContext CreateDbContext(string[] args)
        {
            eProcurementV2EfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<eProcurementV2DbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new eProcurementV2DbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../SerComm.eProcurementV2.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
