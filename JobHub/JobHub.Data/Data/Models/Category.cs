using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobHub.Infrastructure.Common;

namespace JobHub.Infrastructure.Data.Models
{
    public class Category
    {
        public Category()
        {
            Jobs = new List<Job>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(CategoryConstraints.CATEGORY_LABEL_MAX_LENGTH)]
        public string Label { get; set; } = null!;

        public ICollection<Job> Jobs { get; set; }
    }
}
