using JobHub.Core.Constants;
using JobHub.Core.Contracts;
using JobHub.Core.Models.Company;
using JobHub.Extensions;
using Microsoft.AspNetCore.Mvc;


namespace JobHub.Controllers
{
    public class CompanyController : BaseController
    {
        private readonly ICompanyService companyService;

        public CompanyController(ICompanyService _companyService)
        {
            companyService= _companyService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.Id();
            var model = await companyService.GetMineAsync(userId);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {

            var model = new AddCompanyViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddCompanyViewModel model)
        {
            var userId = User.Id();

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (await companyService.UserWithPhoneNumberExists(model.PhoneNumber))
            {
                TempData[MessageConstant.ErrorMessage] = "A company with this phone number already exists";

                return RedirectToAction("Index", "Home");
            }

            await companyService.Create(model,userId);

            return RedirectToAction("Index", "Company");
        }

        [HttpGet]
        public IActionResult Details()
        {
            return View();
        }
    }
}
