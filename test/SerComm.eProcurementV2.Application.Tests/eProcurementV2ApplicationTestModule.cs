using Volo.Abp.Modularity;

namespace SerComm.eProcurementV2
{
    [DependsOn(
        typeof(eProcurementV2ApplicationModule),
        typeof(eProcurementV2DomainTestModule)
        )]
    public class eProcurementV2ApplicationTestModule : AbpModule
    {

    }
}