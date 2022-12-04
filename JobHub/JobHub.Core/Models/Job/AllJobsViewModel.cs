using JobHub.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobHub.Core.Models.Job
{
    public class AllJobsViewModel
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        public string City { get; set; } = null!;
        public decimal? Salary { get; set; }

        public int CompanyId { get; set; }

        public IEnumerable<Infrastructure.Data.Models.Company> Companies { get; set; } =
            new List<Infrastructure.Data.Models.Company>();
        public int CategoryId { get; set; }

        public IEnumerable<Infrastructure.Data.Models.Category> Categories { get; set; } =
            new List<Infrastructure.Data.Models.Category>();
    }
}
