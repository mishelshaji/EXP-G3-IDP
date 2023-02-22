using Idp.Service.Dto;
using Idp.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Idp.WebApp.Areas.Admin.Controllers
{
    public class AdminController : AdminControllerBase
    {
        private readonly AdminService _services;

        public AdminController(AdminService services)
        {
            _services = services;
        }
        [HttpGet]
        [ProducesResponseType(typeof(AdminViewDto[]),StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _services.GetAll();
            return Ok(result);
        }
    }
}
