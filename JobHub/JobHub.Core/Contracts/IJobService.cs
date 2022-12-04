using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobHub.Core.Models.Category;
using JobHub.Core.Models.Company;
using JobHub.Core.Models.Job;
using JobHub.Infrastructure.Data.Models;

namespace JobHub.Core.Contracts
{
    public interface IJobService
    {
        Task<IEnumerable<Category>> AllCategories();
        Task<IEnumerable<string>> AllCategoriesLabels();
        Task Add(AddJobViewModel model);
        Task<bool> Exists(int id);
        Task Delete(int id);
        Task<JobViewModel> JobDetailsById(int id);
        Task<Job> JobById(int id);
        Task Edit(int id, JobViewModel model);

        Task<JobQueryModel> AllJobs(string? category = null, 
            string? searchTerm = null,
            JobSorting sorting=JobSorting.Newest,
            int jobPerPages=10);
    }
}
