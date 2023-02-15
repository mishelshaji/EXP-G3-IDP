using Microsoft.AspNetCore.Mvc;

namespace Idp.WebApp.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Route("api/[area]/[controller]")]
    [ApiController]
    public class ManagerControllerBase : ControllerBase
    {
    }
}
