using Idp.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Idp.WebApp.Areas.Admin.Controllers
{
    public class ManagerController : AdminControllerBase
    {
        private readonly ManagerService _service;

        public ManagerController(ManagerService services)
        {
            this._service = services;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ViewManagerDto[]), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllAsync()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ViewManagerDto[]), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetAsync(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ViewManagerDto[]), StatusCodes.Status201Created)]
        public async Task<ActionResult> Post(CreateManagerDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return Ok(result);
            //return CreatedAtAction(nameof(GetAsync), new { id = result.Id }, result);
        }
    }
}
