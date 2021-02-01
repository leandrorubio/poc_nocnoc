using Domain.Adapters;
using Microsoft.Extensions.DependencyInjection;

namespace Pop
{
    public static class PopModuleDependency
    {
        public static void AddServiceNowModule(this IServiceCollection services)
        {
            services.AddScoped<IServiceNow, ScriptPop>();
        }
    }
}
