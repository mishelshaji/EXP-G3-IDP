using Idp.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Idp.WebApp.Areas.Admin.Controllers
{
    public class EmployeeController : AdminControllerBase
    {
        private readonly EmployeeServices _services;

        public EmployeeController(EmployeeServices services)
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

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ViewEmployeeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update(int id, UpdateEmployeeDto dto)
        {

            var result = await _services.UpdateAsync(id, dto);

            return Ok(result);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult> Post(AddEmployeeDto dto)
        {
            var result = await _services.CreateAsync(dto);
            return Ok(result);
        }
    }
}
