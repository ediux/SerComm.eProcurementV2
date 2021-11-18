using SerComm.eProcurementV2.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace SerComm.eProcurementV2.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(eProcurementV2EntityFrameworkCoreModule),
        typeof(eProcurementV2ApplicationContractsModule)
        )]
    public class eProcurementV2DbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
