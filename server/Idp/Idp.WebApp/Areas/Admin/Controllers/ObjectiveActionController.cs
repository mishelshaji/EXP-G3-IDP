using Idp.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Idp.WebApp.Areas.Admin.Controllers
{
    public class ObjectiveActionController : AdminControllerBase
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
            var result = await _service.GetByObjectiveAsync(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
