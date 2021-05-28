using System;
using System.Collections.Generic;
using Keepr.Server.Models;
using Keepr.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Server.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly AccountService _accountService;
        private readonly KeepsService _keepsService;
        private readonly VaultsService _vaultsService;

    public ProfilesController(AccountService accountService, KeepsService keepsService, VaultsService vs)
        {
            _accountService = accountService;
            _keepsService = keepsService;
            _vaultsService = vs;
        }


        [HttpGet("{id}")]
        public ActionResult<Profile> GetProfileById(string id)
        {
            try
            {
                Profile profile = _accountService.GetProfileById(id);
                return Ok(profile);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/keeps")]
        public ActionResult<List<Keep>> GetKeepsByProfileId(string id)
        {
            try
            {
                List<Keep> keeps = _keepsService.GetKeepsByProfileId(id);
                return Ok(keeps);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("{id}/vaults")]
        public ActionResult<List<Vault>> GetVaultsByProfileId(string id)
        {
            try
            {
                List<Vault> vaults = _vaultsService.GetVaultsByProfileId(id);
                return Ok(vaults);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
















    }
}