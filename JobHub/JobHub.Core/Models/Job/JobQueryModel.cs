using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobHub.Core.Models.Job
{
    public class JobQueryModel
    {
        public int TotalJobsCount { get; set; }

        public IEnumerable<AllJobsViewModel> Jobs { get; set; } = new List<AllJobsViewModel>();
    }
}
