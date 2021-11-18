using SerComm.eProcurementV2.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace SerComm.eProcurementV2.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class eProcurementV2Controller : AbpController
    {
        protected eProcurementV2Controller()
        {
            LocalizationResource = typeof(eProcurementV2Resource);
        }
    }
}