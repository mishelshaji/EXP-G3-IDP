using idp.Service.Services;
using Idp.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Idp.WebApp.Areas.Manager.Controllers
{
    public class PendingObjectiveController : ManagerControllerBase

    {
        private readonly ObjectivePendingService _service;

        public PendingObjectiveController(ObjectivePendingService services)
        {
            this._service = services;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ViewPendingObjectiveDto[]), StatusCodes.Status200OK)]
        public ActionResult GetAllAsync()
        {
            string managerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = _service.GetAll(managerId);
            return Ok(result);
        }
    }
}
