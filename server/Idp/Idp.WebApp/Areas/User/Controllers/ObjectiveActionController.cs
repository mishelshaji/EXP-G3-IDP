using Idp.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Idp.WebApp.Areas.User.Controllers
{
    public class ObjectiveActionController : ManagerControllerBase
    {
        private readonly ObjectiveActionServices _services;

        public ObjectiveActionController(ObjectiveActionServices services)
        {
            this._services = services;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ViewEmployeeDto[]), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllAsync()
        {
            var result = await _services.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ViewEmployeeDto[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetAsync(int id)
        {
            var result = await _services.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post(AddActionDto dto)
        {
            var result = await _services.CreateAsync(dto);
            return Ok(result);
        }
    }
}
