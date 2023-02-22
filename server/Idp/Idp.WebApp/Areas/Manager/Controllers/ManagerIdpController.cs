using idp.Service.Dto;
using idp.Service.Services;
using Idp.WebApp.Areas.Manager.Controllers;
using Idp.WebApp.Areas.User.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Idp.WebApp.Controllers
{
    [Authorize(Roles = "User,Manager")]
    public class ManagerIdpController : ManagerControllerBase
    {
        private readonly IdpService _service;

        public ManagerIdpController(IdpService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IdpViewDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetById(string id)
        {
            var result = await _service.GetByIdAsync(id);
            return result == null ? NotFound() : Ok(result);

        }
    }
}
