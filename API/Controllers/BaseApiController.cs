using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController] // This attribute tells ASP.NET Core that this class is an API controller
    [Route("api/[controller]")] // This attribute tells ASP.NET Core that this controller is accessible via the /api/products route
    public class BaseApiController : ControllerBase
    {

    }
}