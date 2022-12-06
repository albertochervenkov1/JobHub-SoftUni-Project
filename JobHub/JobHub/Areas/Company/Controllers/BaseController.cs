using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static JobHub.Areas.Company.Constants.CompanyConstants;

namespace JobHub.Areas.Company.Controllers
{
    [Area(AreaName)]
    [Route("Company/[controller]/[Action]/{id?}")]
    [Authorize]
    public class BaseController : Controller
    {
        
    }
}
