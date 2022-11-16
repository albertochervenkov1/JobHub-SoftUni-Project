using JobHub.Core.Constants;
using JobHub.Core.Contracts;
using JobHub.Core.Models.Category;
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

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            if (await companyService.ExistsById(User.Id()))
            {
                TempData[MessageConstant.ErrorMessage] = "You already have a company";

                return RedirectToAction("Index", "Home");
            }

            var model = new AddCompanyViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddCompanyViewModel model)
        {
            model.UserId = User.Id();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await companyService.ExistsById(model.UserId))
            {
                TempData[MessageConstant.ErrorMessage] = "You already have a company";

                return RedirectToAction("Index", "Home");
            }

            if (await companyService.UserWithPhoneNumberExists(model.PhoneNumber))
            {
                TempData[MessageConstant.ErrorMessage] = "A company with this phone number already exists";

                return RedirectToAction("Index", "Home");
            }

            

            await companyService.Create(model);

            return RedirectToAction("Index", "Company");
        }
    }
}
