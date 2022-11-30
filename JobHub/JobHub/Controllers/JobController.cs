using JobHub.Core.Contracts;
using JobHub.Core.Models.Job;
using JobHub.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace JobHub.Controllers
{
    public class JobController:BaseController
    {
        private readonly IJobService jobService;

        public JobController(IJobService _jobService)
        {
            jobService= _jobService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            //TODO: If a normal user tries to add a job, should be redirected to Become company page.

            var model = new AddJobViewModel()
            {
                JobCategories = await jobService.AllCategories()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddJobViewModel model)
        {
            model.JobCategories = await jobService.AllCategories();

            if (!ModelState.IsValid)
            {
                model.JobCategories = await jobService.AllCategories();

                return View(model);
            }

            return RedirectToAction(nameof(Preview),model);
        }

        [HttpGet]
        public async Task<IActionResult> Preview(AddJobViewModel model)
        {
            model.JobCategories = await jobService.AllCategories();
            return View(model);
        }

        [ActionName("Preview")]
        [HttpPost]
        public async Task<IActionResult> AddPreview(AddJobViewModel model)
        {
            await jobService.Add(model);
            return RedirectToAction(nameof(Index));
        }

    }
}
