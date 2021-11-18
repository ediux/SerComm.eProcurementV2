using SerComm.eProcurementV2.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace SerComm.eProcurementV2
{
    [DependsOn(
        typeof(eProcurementV2EntityFrameworkCoreTestModule)
        )]
    public class eProcurementV2DomainTestModule : AbpModule
    {

    }
}