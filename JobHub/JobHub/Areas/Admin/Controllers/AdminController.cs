using Microsoft.AspNetCore.Mvc;

namespace JobHub.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
