using Domain.Adapters;
using Domain.Entities;
using Domain.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class NocService : INocService
    {
        private readonly IServiceNow _serviceNow;
        private readonly IPopService _popService;
        private readonly ITeamsComunicator _teamsComunicator;
        public NocService( IServiceNow serviceNow, IPopService popService, ITeamsComunicator teamsComunicator) =>
            (_serviceNow, _popService, _teamsComunicator) = (serviceNow, popService, teamsComunicator);

        
        public async Task AlertAsync(string ic, string type, string popId)
        {
            string userNameLastGMud = await _serviceNow.GetUserNameByIc(ic);
            string urlPopWiki = string.Empty;

            var resultPop = await _popService.ExecuteAsync(popId);
            if (!resultPop)
            {
                urlPopWiki = popWiki(popId);
                await _teamsComunicator.SendMessage(userNameLastGMud, type , urlPopWiki);   
            }
            await _serviceNow.InsertAlert(ic, type, resultPop);
        }

        private string popWiki(string popId)
        {
            return "http://www.xpi.com.br";
        }

    }
}
