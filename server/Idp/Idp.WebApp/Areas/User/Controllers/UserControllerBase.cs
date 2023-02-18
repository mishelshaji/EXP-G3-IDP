using Microsoft.AspNetCore.Mvc;

namespace Idp.WebApp.Areas.User.Controllers
{
    [Area("User")]
    [Route("api/[area]/[controller]")]
    [ApiController]
    public class UserControllerBase : ControllerBase
    {
    }
}
