using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobHub.Core.Models.Category;
using JobHub.Core.Models.Job;

namespace JobHub.Core.Contracts
{
    public interface IJobService
    {
        Task<IEnumerable<CategoryViewModel>> AllCategories();
        Task Add(AddJobViewModel model);
    }
}
