using Domain.Adapters;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flurl.Http;
using System.Net.Http;
using RestSharp;
using System.Net;

namespace Infra.ServiceNow.External
{
    public class Servicenow : IServiceNow
    {
        public async Task<IEnumerable<Teste>> GetAllAsync()
        {

            var url = "https://dev60115.service-now.com/api/sn_chg_rest/change?sysparm_query=cmdb_ciLIKE.Net^ORDERBYDESCopened_at";

            var request = await url.AllowHttpStatus("400-499, 200-299")
                                   .WithCookies(out var jar)
                                   .WithHeader("Accept", "application/json")
                                   .WithBasicAuth("admin", "BK9SbxED4jam")
                                   .GetAsync();

            if (request.StatusCode == (int)HttpStatusCode.Unauthorized)
            {
                request = await url.AllowHttpStatus("400-499, 200-299")
                                   .WithCookies(jar)
                                   .WithHeader("Accept", "application/json")
                                   .WithBasicAuth("admin", "BK9SbxED4jam")
                                   .GetAsync();
            }

            var responseSn = await request.GetJsonAsync<ChangeRequest>();
            string name = responseSn.Result.First().User.AssignedToName;
           
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Teste
            {
                Id = rng.Next(-20, 55),
                Name = name
            });
        }


        public async Task<string> GetUserNameByIc(string ic)
        {
            var url = "https://dev60115.service-now.com/api/sn_chg_rest/change?sysparm_query=cmdb_ciLIKE.Net^ORDERBYDESCopened_at";

            var request = await url.AllowHttpStatus("400-499, 200-299")
                                   .WithCookies(out var jar)
                                   .WithHeader("Accept", "application/json")
                                   .WithBasicAuth("admin", "BK9SbxED4jam")
                                   .GetAsync();

            if (request.StatusCode == (int)HttpStatusCode.Unauthorized)
            {
                request = await url.AllowHttpStatus("400-499, 200-299")
                                   .WithCookies(jar)
                                   .WithHeader("Accept", "application/json")
                                   .WithBasicAuth("admin", "BK9SbxED4jam")
                                   .GetAsync();
            }

            var responseSn = await request.GetJsonAsync<ChangeRequest>();
            return  responseSn.Result.FirstOrDefault().User.AssignedToName;
        }

        public async Task InsertAlert(string ic, string type, bool closed)
        {

        }
    }
}
