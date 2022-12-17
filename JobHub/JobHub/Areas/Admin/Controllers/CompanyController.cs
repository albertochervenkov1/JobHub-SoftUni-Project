using JobHub.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace JobHub.Areas.Admin.Controllers
{
    public class CompanyController : BaseController
    {
        private readonly ICompanyService companyService;

        public CompanyController(ICompanyService _companyService)
        {
            companyService = _companyService;
        }

        public async Task<IActionResult> All()
        {
            var model = await companyService.AllCompanies();
            return View(model);
        }
    }
}
