using Idp.WebApp.Areas.Admin.Controllers;
using Idp.WebApp.Areas.User.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace Idp.WebApp.Areas.Admin
{
    [Authorize(Roles = "Admin")]
    public class EmployeeController : AdminControllerBase
    {
        private readonly EmployeeService _service;

        public EmployeeController(EmployeeService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(typeof(EmployeeViewDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromForm] EmployeeUploadDto dto)
        {
            var result = await _service.CreateAsync(dto);
            if (!result.IsValid)
                return BadRequest(result.Errors);

            return Ok(result);

            //return CreatedAtAction(nameof(GetOne), new { id = result.Result.Id }, result.Result);
        }

    }
}
