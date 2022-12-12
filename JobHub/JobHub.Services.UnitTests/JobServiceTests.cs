using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobHub.Core.Contracts;
using JobHub.Core.Models.Job;
using JobHub.Core.Services;
using JobHub.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JobHub.Services.UnitTests
{
    [TestFixture]
    public class JobServiceTests:UnitTestBase
    {
        private IJobService jobService;

        [SetUp]
        public void SetUp()
        {
            this.jobService = new JobService(repo);
        }

        [Test]
        public async Task Test_GetAllCategories()
        {
            int dbCategoriesCount = repo.AllReadonly<Category>()
                .Count();

            var categories = await jobService.AllCategories();

            Assert.That(dbCategoriesCount, Is.EqualTo(categories.Count()));
        }

        [Test]
        public async Task Test_GetAllCategoriesLabels()
        {
            var expectedCategoriesLabels = await repo.AllReadonly<Category>()
                .Select(c => c.Label)
                .ToListAsync();

            var categoriesLabels = await jobService.AllCategoriesLabels();

            Assert.That(expectedCategoriesLabels.Count, Is.EqualTo(categoriesLabels.Count()));
        }


        [Test]
        public async Task Test_AddJobSuccessfully()
        {
            var initialJobCount = repo.AllReadonly<Job>()
                .Count();

            var model = new AddJobViewModel()
            {
                Title = "Job Title",
                Description = "Job description",
                City = "City",
                Salary = 1450,
                CategoryId = 1,
                CompanyId = 1
            };

            await jobService.Add(model);

            var jobCount= repo.AllReadonly<Job>()
                .Count();
            
            Assert.That(initialJobCount+1,Is.EqualTo(jobCount));

            Job? addedJob = await repo.AllReadonly<Job>()
                .OrderByDescending(j => j.Id)
                .FirstOrDefaultAsync();

            Assert.That(addedJob, Is.Not.Null);
            Assert.That(addedJob?.Title,Is.EqualTo(model.Title));
            Assert.That(addedJob?.Description,Is.EqualTo(model.Description));
            Assert.That(addedJob?.City,Is.EqualTo(model.City));
            Assert.That(addedJob?.Salary,Is.EqualTo(model.Salary));
            Assert.That(addedJob?.CategoryId,Is.EqualTo(model.CategoryId));
            Assert.That(addedJob?.CompanyId,Is.EqualTo(model.CompanyId));

        }

        [Test]
        public async Task Test_JobExistsById()
        {
            var jobId = 2;

            var result=await jobService.Exists(jobId);

            Assert.That(result,Is.True);
        }

        [Test]
        public async Task Test_DeleteJobSuccessfully()
        {
            var model = new AddJobViewModel()
            {
                Title = "Job Title",
                Description = "Job description",
                City = "City",
                Salary = 1450,
                CategoryId = 1,
                CompanyId = 1
            };
            await jobService.Add(model);

            var initialJobCount = repo.AllReadonly<Job>()
                .Count();

            Job? addedJob=await repo.AllReadonly<Job>()
                .OrderByDescending(j=>j.Id)
                .FirstOrDefaultAsync();

            await jobService.Delete(addedJob.Id);

            var jobsCountAfterDelete = repo.AllReadonly<Job>()
                .Count();

            Assert.That(initialJobCount-1,Is.EqualTo(jobsCountAfterDelete));

            Assert.That(addedJob, Is.Not.Null);
            Assert.That(addedJob?.Title, Is.EqualTo(model.Title));
            Assert.That(addedJob?.Description, Is.EqualTo(model.Description));
            Assert.That(addedJob?.City, Is.EqualTo(model.City));
            Assert.That(addedJob?.Salary, Is.EqualTo(model.Salary));
            Assert.That(addedJob?.CategoryId, Is.EqualTo(model.CategoryId));
            Assert.That(addedJob?.CompanyId, Is.EqualTo(model.CompanyId));
        }

        [Test]
        public async Task Test_JobDetailsById()
        {
            var id = 2;

            var model = await jobService.JobDetailsById(id);

            Assert.That(id,Is.EqualTo(model.Id));
        }

        [Test]
        public async Task Test_JobById()
        {
            var id = 2;

            var jobById = await jobService.JobById(id);

            Assert.That(id,Is.EqualTo(jobById.Id));
        }

        [Test]
        public async Task Test_EditJob_ChangesSuccessfully()
        {
            var jobId = 2;

            var model = new JobViewModel()
            {
                Title = "New Job Title",
                Description = "New Job Description",
                City = "New Job City",
                Salary = 3000,
                CategoryId = 1,

            };

            await jobService.Edit(jobId, model);

            Job job = await repo.GetByIdAsync<Job>(jobId);

            Assert.That(job, Is.Not.Null);
            Assert.That(job.Title,Is.EqualTo(model.Title));
            Assert.That(job.Description,Is.EqualTo(model.Description));
            Assert.That(job.City,Is.EqualTo(model.City));
            Assert.That(job.Salary,Is.EqualTo(model.Salary));
            Assert.That(job.CategoryId,Is.EqualTo(model.CategoryId));
        }

        [Test]
        public async Task Test_DetailedJobByID()
        {
            var id = 2;

            var model = await jobService.DetailedJobById(id);

            Assert.That(id, Is.EqualTo(model.Id));
        }
    }
}
