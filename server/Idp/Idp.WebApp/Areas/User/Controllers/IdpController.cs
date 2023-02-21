using idp.Service.Dto;
using idp.Service.Services;
using Idp.WebApp.Areas.User.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Idp.WebApp.Controllers
{
    [Authorize(Roles = "User,Manager")]
    public class IdpController : UserControllerBase
    {
        private readonly IdpService _service;

        public IdpController(IdpService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(typeof(IdpViewDto), StatusCodes.Status200OK)]
        public async Task<ActionResult> Post(CreateIdpDto dto)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _service.AddIdpAsync(dto, userId);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IdpViewDto), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetIdp()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _service.GetIdpAsync(userId);
            return Ok(result);

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
