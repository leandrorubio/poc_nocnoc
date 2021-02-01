using Infra.BotTeams.External;
using Domain.Adapters;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.BotTeams
{
    public static class BotTeamsModuleDependency
    {
        public static void AddBotTeamsModule(this IServiceCollection services)
        {
            services.AddScoped<ITeamsComunicator, TeamsComunicator>();
        }
    }
}
