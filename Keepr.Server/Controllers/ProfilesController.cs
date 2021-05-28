using Keepr.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Server.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly AccountService _accountService;

        public ProfilesController(AccountService accountService)
        {
            _accountService = accountService;
        }
    }
}