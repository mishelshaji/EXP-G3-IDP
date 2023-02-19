﻿using Idp.Service.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Idp.WebApp.Areas.Admin.Controllers
{

    public class CategoriesController : AdminControllerBase
    {
        private readonly CategoryService _service;

        public CategoriesController(CategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(CategoryViewDto[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CategoryViewDto[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOne(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CategoryViewDto[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post(CategoryCreateDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return Ok(result);
        }
    }
}