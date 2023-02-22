using Idp.Service.Service;
using Idp.WebApp.Areas.Manager.Controllers;
using IDP.Service.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace Idp.WebApp.Areas.User.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ManagerObjectiveControllers : ManagerControllerBase
    {
        private readonly ObjectiveService _service;

        public ManagerObjectiveControllers(ObjectiveService service)
        {
            _service = service;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ObjectiveViewDto[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post(int id, ObjectiveUpdateDto dto)
        {
            var result = await _service.UpdateAsync(id, dto);
            return Ok(result);
        }

    }
}
