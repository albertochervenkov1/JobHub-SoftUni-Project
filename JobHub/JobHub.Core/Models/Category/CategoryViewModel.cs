using JobHub.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobHub.Core.Models.Category
{
    public  class CategoryViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(CategoryConstraints.CATEGORY_LABEL_MAX_LENGTH)]
        public string Label { get; set; } = null!;
    }
}
