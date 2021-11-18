using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace SerComm.eProcurementV2.Data
{
    /* This is used if database provider does't define
     * IeProcurementV2DbSchemaMigrator implementation.
     */
    public class NulleProcurementV2DbSchemaMigrator : IeProcurementV2DbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}