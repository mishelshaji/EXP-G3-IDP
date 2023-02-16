using Microsoft.AspNetCore.Mvc;

namespace Idp.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("api/[area]/[controller]")]
    [ApiController]
    public class UserControllerBase : ControllerBase
    {
    }
}
