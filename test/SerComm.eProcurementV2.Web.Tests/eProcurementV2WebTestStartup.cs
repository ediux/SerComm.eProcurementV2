using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace SerComm.eProcurementV2
{
    public class eProcurementV2WebTestStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<eProcurementV2WebTestModule>();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.InitializeApplication();
        }
    }
}