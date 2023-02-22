using idp.Service.Services;
using Idp.Service.Services;
using Idp.WebApp.Areas.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Idp.WebApp.Areas.Manager.Controllers
{
    public class AdminEmployeeList : AdminControllerBase

    {
        private readonly ObjectivePendingService _service;

        public AdminEmployeeList(ObjectivePendingService services)
        {
            this._service = services;
        }

        [HttpGet("{managerId}")]
        [ProducesResponseType(typeof(ViewPendingObjectiveDto[]), StatusCodes.Status200OK)]
        public ActionResult GetAllAsync(string managerId)
        {
            var result = _service.GetAll(managerId);
            return Ok(result);
        }
    }
}
