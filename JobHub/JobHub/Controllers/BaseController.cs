using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobHub.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        
    }
}
