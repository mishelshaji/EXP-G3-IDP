using Idp.Service.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace Idp.WebApp.Areas.User.Controllers
{
    [Authorize(Roles = "User,Manager")]
    public class ObjectivesControllers : UserControllerBase
    {
        private readonly ObjectiveService _service;

        public ObjectivesControllers(ObjectiveService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ObjectiveViewDto[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(int id)
        {
            var result = await _service.GetByIdpAsync(id);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ObjectiveViewDto[]), StatusCodes.Status201Created)]
        public async Task<IActionResult> Post(ObjectiveCreateDto dto)
        {

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _service.CreateAsync(dto, userId);
            return Ok(result);
        }

        [HttpGet("{year}")]
        [ProducesResponseType(typeof(ObjectiveViewDto[]), StatusCodes.Status200OK)]
        public IActionResult GetProgress(int year)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = _service.GetProgress(userId, year);
            return Ok(result);
        }

    }
}
