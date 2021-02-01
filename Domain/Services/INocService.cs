using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface INocService
    {
        Task AlertAsync(string ic, string type, string popId);
    }
}
