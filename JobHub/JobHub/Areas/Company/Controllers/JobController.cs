﻿using JobHub.Core.Contracts;
using JobHub.Core.Models.Job;
using Microsoft.AspNetCore.Mvc;

namespace JobHub.Areas.Company.Controllers
{
    public class JobController : BaseController
    {
        private readonly IJobService jobService;
        private readonly ICompanyService companyService;
        public JobController(IJobService _jobService,
            ICompanyService _companyService)
        {
            jobService = _jobService;
            companyService = _companyService;
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

            if ((await companyService.CompanyExists(model.CategoryId)) == false)
            {
                ModelState.AddModelError(nameof(model.CompanyId), "Company doesn't exist!");
            }

            await jobService.Add(model);

            var id = model.CompanyId;
            return RedirectToAction("Details", "Company", new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await jobService.JobDetailsById(id);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var job = await jobService.JobDetailsById(id);

            var model = new JobViewModel()
            {
                Id = job.Id,
                Description = job.Description,
                Title = job.Title,
                City = job.City,
                Salary = job.Salary,
                CreatedDate = job.CreatedDate,
                CategoryId = job.CategoryId,
                CompanyId = job.CompanyId,
                JobCategories = await jobService.AllCategories()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, JobViewModel model)
        {
            if (id != model.Id)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await jobService.Edit(model.Id, model);


            return RedirectToAction(nameof(Details), new { id });


        }

        public async Task<IActionResult> Delete(int id)
        {
            if ((await jobService.Exists(id)) == false)
            {
                return RedirectToAction("Details", "Company");
            }

            var job = jobService.JobById(id);
            var companyId = job.Result.CompanyId;

            await jobService.Delete(id);

            id = companyId;
            return RedirectToAction("Details", "Company", new { id });
        }

        public IActionResult BackToCompany(int id)
        {
            return RedirectToAction("Details", "Company", new { id });
        }

        [HttpGet]
        public async Task<FileResult> DownLoadFile(int id)
        {
            var file = await jobService.FileById(id);
            var result = new FileContentResult(file.FileContext, "application/pdf")
            {
                FileDownloadName = file.Name
            };

            // Return the FileContentResult object.
            return result;
        }
    }
}
