using Idp.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Idp.WebApp.Areas.User.Controllers
{
    public class ObjectiveActionController : ManagerControllerBase
    {
        private readonly ObjectiveActionServices _service;

        public ObjectiveActionController(ObjectiveActionServices services)
        {
            this._service = services;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ViewActionDto[]), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllAsync()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ViewActionDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetAsync(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ViewActionDto), StatusCodes.Status201Created)]
        public async Task<ActionResult> Post(AddActionDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetAsync), new { id = result.Id }, result);
        }
    }
}
