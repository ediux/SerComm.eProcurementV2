using System;
using System.Collections.Generic;
using System.Text;
using SerComm.eProcurementV2.Localization;
using Volo.Abp.Application.Services;

namespace SerComm.eProcurementV2
{
    /* Inherit your application services from this class.
     */
    public abstract class eProcurementV2AppService : ApplicationService
    {
        protected eProcurementV2AppService()
        {
            LocalizationResource = typeof(eProcurementV2Resource);
        }
    }
}
