using Domain.Adapters;
using Domain.Entities;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
   public class PopService : IPopService
    {
               
        public Task<bool> ExecuteAsync(string popId)
        {
            return Task.FromResult(false);
        }

    }
}
