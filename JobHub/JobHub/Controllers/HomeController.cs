using JobHub.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JobHub.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                if (User?.IsInRole("Admin") ?? false)
                {
                    return RedirectToAction("Index", "Admin", new { area = "Admin" });
                }
                return RedirectToAction("Index", "Home", new { area = "Company" });
            }
            return View();
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}