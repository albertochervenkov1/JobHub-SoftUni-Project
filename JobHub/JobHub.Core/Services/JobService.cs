using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobHub.Core.Contracts;
using JobHub.Core.Models.Category;
using JobHub.Core.Models.Company;
using JobHub.Core.Models.Job;
using JobHub.Infrastructure.Data.Common;
using JobHub.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JobHub.Core.Services
{
    public class JobService:IJobService
    {
        private readonly IRepository repo;

        public JobService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<IEnumerable<Category>> AllCategories()
        {
            return await repo.AllReadonly<Category>().ToListAsync();

        }
        public async Task Add(AddJobViewModel model)
        {
            //var datetime = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            var job = new Job()
            {
                Title = model.Title,
                CategoryId = model.CategoryId,
                Description = model.Description,
                Salary = model.Salary,
                CompanyId = model.CompanyId,
                City = model.City,
                CreatedDate = DateTime.ParseExact(DateTime.Now.ToString(CultureInfo.InvariantCulture), "MM/dd/yyyy HH:mm:ss",CultureInfo.InvariantCulture)
            };

            await repo.AddAsync(job);
            await repo.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await repo.AllReadonly<Job>()
                .AnyAsync(j => j.Id == id);
        }

        public async Task Delete(int id)
        {
            
            await repo.DeleteAsync<Job>(id);
            await repo.SaveChangesAsync();
        }

        public async Task<JobViewModel> JobDetailsById(int id)
        {
            return await repo.AllReadonly<Job>()
                .Where(j => j.Id == id)
                .Select(j => new JobViewModel()
                {
                    Id = j.Id,
                    Title = j.Title,
                    CreatedDate = j.CreatedDate,
                    Salary = j.Salary,
                    Description = j.Description,
                    CompanyId = j.CompanyId,
                    CategoryId = j.CategoryId,
                    City = j.City,
                }).FirstAsync();
        }

        public async Task<Job> JobById(int id)
        {
            return await repo.GetByIdAsync<Job>(id);
        }

        public async Task Edit(int id, JobViewModel model)
        {
            var job = await repo.GetByIdAsync<Job>(id);

            job.Title = model.Title;
            job.Description = model.Description;
            job.Salary = model.Salary;
            job.CategoryId = model.CategoryId;
            job.City=model.City;

            await repo.SaveChangesAsync();
        }
    }
}
