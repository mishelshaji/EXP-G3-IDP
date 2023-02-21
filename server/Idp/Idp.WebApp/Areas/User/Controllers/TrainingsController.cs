using Idp.WebApp.Areas.User.Controllers;
using IDP.Service.Dto;
using IDP.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace IDP.WebApp.Areas.User.Controllers
{
    [Authorize(Roles = "User,Manager")]
    public class TrainingsController : UserControllerBase
    {
        private readonly TrainingService _service;

        public TrainingsController(TrainingService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(TrainingViewDto[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(TrainingViewDto), StatusCodes.Status201Created)]
        public async Task<IActionResult> Post(TrainingCreateDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TrainingViewDto[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByObjectiveId(int id)
        {
            var result = await _service.GetByObjectiveAsync(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TrainingViewDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, TrainingUpdateDto dto)
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
