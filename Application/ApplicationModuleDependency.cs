using Application.Services;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationModuleDependency
    {
        public static void AddApplicationModule(this IServiceCollection services)
        {
            services.AddTransient<INocService, NocService>();
            services.AddTransient<IPopService, PopService>();
        }
    }
}
