using JobHub.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobHub.Infrastructure.Data.Models;

namespace JobHub.Core.Models.Job
{
    public  class JobViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal? Salary { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CompanyId { get; set; }
        public int CategoryId { get; set; }
        
        public string City { get; set; } = null!;

        public IEnumerable<Infrastructure.Data.Models.Category> JobCategories { get; set; } =
            new List<Infrastructure.Data.Models.Category>();

        public ICollection<CvFile> Files { get; set; } = new List<CvFile>();
    }
}
