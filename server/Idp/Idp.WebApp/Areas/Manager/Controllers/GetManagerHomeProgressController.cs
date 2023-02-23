using idp.Service.Dto;
using idp.Service.Services;
using Idp.WebApp.Areas.Manager.Controllers;
using Idp.WebApp.Areas.User.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Idp.WebApp.Controllers
{
    [Authorize(Roles = "Manager")]
    public class GetManagerHomeProgressController : ManagerControllerBase
    {
        private readonly ObjectivePendingService _service;

        public GetManagerHomeProgressController(ObjectivePendingService service)
        {
            _service = service;
        }
        [HttpGet]
        [ProducesResponseType(typeof(GetManagerHomeProgressDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        public ActionResult GetManagerHomeProgress()
        {
            string managerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = _service.GetManagerHomeProgress(managerId);
            return result == null ? NotFound() : Ok(result);

        }
    }
}
