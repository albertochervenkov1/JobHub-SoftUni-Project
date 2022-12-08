using JobHub.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobHub.Core.Models.Company
{
    public class AddCompanyViewModel
    {
        [Required]
        [StringLength(CompanyConstraints.NAME_MAX_LENGTH)]
        public string Name { get; set; } = null!;
        public string? City { get; set; }

        [Required]
        [StringLength(CompanyConstraints.PHONE_NUMBER_MAX_LENGTH, MinimumLength = CompanyConstraints.PHONE_NUMBER_MIN_LENGTH)]
        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;
    }
}
