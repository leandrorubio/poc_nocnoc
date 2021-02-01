using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Adapters
{
    public interface ITeamsComunicator
    {
        Task SendMessage(string userName, string type, string urlPopWiki);
    }
}
