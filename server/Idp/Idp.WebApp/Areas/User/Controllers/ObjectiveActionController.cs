using Idp.Service.Services;
using IDP.Service.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Idp.WebApp.Areas.User.Controllers
{
    [Authorize(Roles = "User,Manager")]
    public class ObjectiveActionController : UserControllerBase
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

        [HttpPost]
        [ProducesResponseType(typeof(ViewActionDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromForm] AddActionDto dto)
        {
            var result = await _service.CreateAsync(dto);
            if (!result.IsValid)
                return BadRequest(result.Errors);

            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TrainingViewDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, ActionUpdateDto dto)
        {
            var result = await _service.UpdateAsync(id, dto);
            if (result == null)
                return NotFound();

            if (!result.IsValid)
                return BadRequest(result.Errors);

            return Ok(result.Result);
        }
    }
}
