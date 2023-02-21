using Idp.WebApp.Areas.Admin.Controllers;
using IDP.Service.Dto;
using IDP.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Idp.WebApp.Areas.Manager.Controllers
{

    public class TrainingsController : ManagerControllerBase
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
        [ProducesResponseType(typeof(TrainingViewDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOne(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
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
