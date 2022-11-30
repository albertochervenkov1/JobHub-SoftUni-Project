using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobHub.Core.Contracts;
using JobHub.Core.Models.Category;
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
                CreatedDate = DateTime.ParseExact(DateTime.Now.ToString(CultureInfo.InvariantCulture), "MM/dd/yyyy HH:mm:ss",CultureInfo.InvariantCulture)
            };

            await repo.AddAsync(job);
            await repo.SaveChangesAsync();
        }
    }
}
