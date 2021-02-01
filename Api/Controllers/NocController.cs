using System.Threading.Tasks;
using Api.ViewModel;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class NocController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> AlertAsync([FromServices] INocService nocService, AlertRequest request)
        {
            await nocService.AlertAsync(request.Ic, request.Type, request.PopId);
            return Ok();
        }
    }
}
