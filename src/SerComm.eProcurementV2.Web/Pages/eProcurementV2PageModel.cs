using SerComm.eProcurementV2.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace SerComm.eProcurementV2.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class eProcurementV2PageModel : AbpPageModel
    {
        protected eProcurementV2PageModel()
        {
            LocalizationResourceType = typeof(eProcurementV2Resource);
        }
    }
}