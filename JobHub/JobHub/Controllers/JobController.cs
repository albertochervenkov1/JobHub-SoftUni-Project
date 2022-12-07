using JobHub.Core.Contracts;
using JobHub.Core.Models.Company;
using JobHub.Core.Models.Job;
using JobHub.Extensions;
using JobHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.IO;

namespace JobHub.Controllers
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
        public IActionResult Index()
        {
            return View();
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


        [HttpGet]
        public IActionResult UploadFile(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(UploadFileViewModel model,int id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var file = model.File;
            byte[] buffer = new byte[file.Length];
            var resultInBytes = ConvertToBytes(file);
            Array.Copy(resultInBytes, buffer, resultInBytes.Length);
            
            // now you could pass the byte array to your model and store wherever 
            // you intended to store it
            var newFileModel = new UploadFileModel()
            {
                Content = buffer,
                UserId = User.Id(), 
                JobId=id,
                Name = buffer.ToString()
            };

            await jobService.UploadFile(newFileModel);


            return Content("Thanks for uploading the file");
        }
        private byte[] ConvertToBytes(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.OpenReadStream().CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }


        
    }
}
