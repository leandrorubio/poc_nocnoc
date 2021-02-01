using Domain.Adapters;
using Infra.ServiceNow.External;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.ServiceNow
{
    public static class ServiceNowModuleDependency
    {
        public static void AddServiceNowModule(this IServiceCollection services)
        {
            services.AddScoped<IServiceNow, Servicenow>();
        }
    }
}
