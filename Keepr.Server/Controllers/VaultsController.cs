using Keepr.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VaultsController : ControllerBase
    {
        private readonly VaultsService _service;

        public VaultsController(VaultsService service)
        {
            _service = service;
        }
    }
}