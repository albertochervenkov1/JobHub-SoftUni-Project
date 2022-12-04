using JobHub.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobHub.Core.Models.Category;

namespace JobHub.Core.Models.Job
{
    public class AddJobViewModel
    {
        [Required]
        [StringLength(JobConstraints.JOB_TITLE_MAX_LENGTH,MinimumLength = JobConstraints.JOB_TITLE_MIN_LENGTH)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(JobConstraints.JOB_DESCRIPTION_MAX_LENGTH,MinimumLength = JobConstraints.JOB_DESCRIPTION_MIN_LENGTH)]
        public string Description { get; set; } = null!;

        public int CategoryId { get; set; }
        public decimal? Salary { get; set; }

        [Required]
        [StringLength(JobConstraints.JOB_CITY_MAX_LENGTH,MinimumLength = JobConstraints.JOB_CITY_MIN_LENGTH)]
        public string City { get; set; } = null!;
        public int CompanyId { get; set; }

        public IEnumerable<Infrastructure.Data.Models.Category> JobCategories { get; set; } = new List<Infrastructure.Data.Models.Category>();
    }
}
