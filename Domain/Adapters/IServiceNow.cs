using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Adapters
{
    public interface IServiceNow
    {
        Task<IEnumerable<Teste>> GetAllAsync();

        Task<string> GetUserNameByIc(string ic);

        Task InsertAlert(string ic, string type, bool closed);
    }
}
