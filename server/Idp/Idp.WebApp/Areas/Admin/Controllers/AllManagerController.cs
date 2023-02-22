using Idp.WebApp.Areas.Admin.Controllers;
using Idp.WebApp.Areas.User.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace Idp.WebApp.Areas.User.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AllManagerController : AdminControllerBase
    {
        private readonly AccountsService _service;

        public AllManagerController(AccountsService service)
        {
            _service = service;
        }

        [HttpGet("profile")]
        [ProducesResponseType(typeof(ProfileViewDto[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProfile()
        {
            var user = await _service.GetManagerProfileAsync();
            return user == null ? NotFound() : Ok(user);
        }
    }
}
