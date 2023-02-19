using idp.Service.Dto;
using idp.Service.Services;
using Idp.WebApp.Areas.User.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Idp.WebApp.Controllers
{
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
            var result = await _service.AddIdpAsync(dto);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IdpViewDto), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetIdp()
        {
            var result = await _service.GetIdpAsync();
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
