using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static JobHub.Areas.Admin.Constants.AdminConstants;

namespace JobHub.Areas.Admin.Controllers
{
    [Area(AreaName)]
    [Route("/Admin/[controller]/[Action]/{id?}")]
    [Authorize(Roles = AdminRoleName)]
    public class BaseController : Controller
    {
    }
}
