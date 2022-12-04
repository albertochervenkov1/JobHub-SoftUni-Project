using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobHub.Infrastructure.Common;

namespace JobHub.Infrastructure.Data.Models
{
    public  class Job
    {
        [Key]
        public int Id { get; set; }

        [Required] 
        [StringLength(JobConstraints.JOB_TITLE_MAX_LENGTH)] 
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(JobConstraints.JOB_DESCRIPTION_MAX_LENGTH)]
        public string Description { get; set; }= null!;

        [Required]
        [StringLength(JobConstraints.JOB_CITY_MAX_LENGTH)]
        public string City { get; set; } = null!;

        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        public decimal? Salary { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CompanyId { get; set; }

        [ForeignKey(nameof(CompanyId))] 
        public Company Company { get; set; } = null!;


    }
}
