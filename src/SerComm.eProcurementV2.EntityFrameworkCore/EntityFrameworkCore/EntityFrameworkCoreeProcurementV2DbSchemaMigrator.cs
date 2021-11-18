using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SerComm.eProcurementV2.Data;
using Volo.Abp.DependencyInjection;

namespace SerComm.eProcurementV2.EntityFrameworkCore
{
    public class EntityFrameworkCoreeProcurementV2DbSchemaMigrator
        : IeProcurementV2DbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreeProcurementV2DbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the eProcurementV2DbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<eProcurementV2DbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
