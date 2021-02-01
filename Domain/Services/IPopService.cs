using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IPopService
    {
        Task<bool> ExecuteAsync(string popId);
    }
}
