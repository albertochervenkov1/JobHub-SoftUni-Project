using JobHub.Core.Contracts;
using JobHub.Core.Models.Company;
using JobHub.Core.Models.Job;
using JobHub.Extensions;
using JobHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.IO.Compression;

namespace JobHub.Controllers
{
    public class JobController : Controller
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
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery] AllJobsQueryModel query)
        {
            var result = await jobService.AllJobs(
                query.Category,
                query.SearchTerm,
                query.Sorting,
                AllJobsQueryModel.JobsPerPage);

            query.TotalJobsCount = result.TotalJobsCount;
            query.Categories = await jobService.AllCategoriesLabels();
            query.Jobs = result.Jobs;

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> JobDetails(int id)
        {
            var model = await jobService.DetailedJobById(id);
            return View(model);
        }

        

        
    }
}
