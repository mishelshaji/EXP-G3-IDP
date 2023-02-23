using Idp.Service.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace Idp.WebApp.Areas.User.Controllers
{
    [Authorize(Roles = "User,Manager")]
    public class HomePageProgress : UserControllerBase
    {
        private readonly ObjectiveService _service;

        public HomePageProgress(ObjectiveService service)
        {
            _service = service;
        }

        [HttpGet("{year}")]
        [ProducesResponseType(typeof(ObjectiveViewDto[]), StatusCodes.Status200OK)]
        public IActionResult GetProgress(int year)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = _service.GetProgress(userId, year);
            return Ok(result);
        }

    }
}
