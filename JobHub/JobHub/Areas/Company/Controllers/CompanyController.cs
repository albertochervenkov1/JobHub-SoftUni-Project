using JobHub.Core.Constants;
using JobHub.Core.Contracts;
using JobHub.Core.Models.Company;
using JobHub.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace JobHub.Areas.Company.Controllers
{
    
    public class CompanyController : BaseController
    {
        private readonly ICompanyService companyService;

        public CompanyController(ICompanyService _companyService)
        {
            companyService = _companyService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = User.Id();
            var model = await companyService.GetMineAsync(userId);

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(CompanyViewModel model)
        {
            var id = model.Id;
            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        
        public IActionResult Create()
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

            if (await companyService.CompanyWithPhoneNumberExists(model.PhoneNumber))
            {
                TempData[MessageConstant.ErrorMessage] = "A Company with this phone number already exists!";
                return View(model);
            }

            await companyService.Create(model, userId);

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Details(int id)
        {
            var model = await companyService.CompanyDetailsById(id);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var company = await companyService.CompanyDetailsById(id);

            var model = new CompanyViewModel()
            {
                Id = company.Id,
                Name = company.Name,
                City = company.City,
                PhoneNumber = company.PhoneNumber,
                Description = company.Description,
                Email = company.Email
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CompanyViewModel model)
        {
            if (id != model.Id)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            if (await companyService.CompanyWithPhoneNumberExists(model.PhoneNumber))
            {
                TempData[MessageConstant.ErrorMessage] = "A Company with this phone number already exists!";
                return View(model);
            }

            await companyService.Edit(model.Id, model);


            return RedirectToAction(nameof(Details), new { id });


        }

        public IActionResult BackToCompanies(int id)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
