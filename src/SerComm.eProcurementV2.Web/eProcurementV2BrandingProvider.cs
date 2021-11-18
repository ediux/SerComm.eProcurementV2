using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace SerComm.eProcurementV2.Web
{
    [Dependency(ReplaceServices = true)]
    public class eProcurementV2BrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "eProcurementV2";
    }
}
