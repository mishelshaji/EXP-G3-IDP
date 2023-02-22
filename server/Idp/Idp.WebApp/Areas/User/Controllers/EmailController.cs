using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IDP.Service.Dto;
using IDP.Service.Services;

namespace IDP.WebApp.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
        {
        private readonly EmailService _emailService;

        public EmailController(EmailService service)
        {
            _emailService = service;
        }

        [HttpPost]
        public IActionResult SendEmail([FromBody] EmailDto emails)
        {
            _emailService.SendEmail(emails);
            return Ok(emails);
        }

    }
}
