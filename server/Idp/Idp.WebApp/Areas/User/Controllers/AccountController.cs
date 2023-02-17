using Idp.WebApp.Areas.User.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace Idp.WebApp.Areas.User.Controllers
{
    public class AccountsController : UserControllerBase
    {
        private readonly AccountsService _service;

        public AccountsController(AccountsService service)
        {
            _service = service;
        }

        [HttpPost("user/register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostUser(UserCreateDto dto)
        {
            var result = await _service.CreateUserAsync(dto);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            return Ok();
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostLogin(LoginDto dto)
        {
            var result = await _service.LoginAsync(dto);
            if (result.IsValid)
                return Ok(result);

            return BadRequest(result.Errors);
        }

        [Authorize(Roles = "User")]
        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _service.GetProfileAsync(id);
            return user == null ? NotFound() : Ok(user);
        }
    }
}
