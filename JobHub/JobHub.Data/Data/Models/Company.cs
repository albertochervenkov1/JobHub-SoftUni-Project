using Microsoft.AspNetCore.Identity;
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
    public class Company
    {
        public Company()
        {
            Jobs = new List<Job>();
        }
        [Key]
        public int Id { get; set; }

        [Required] 
        [StringLength(CompanyConstraints.NAME_MAX_LENGTH)] 
        public string Name { get; set; } = null!;

        [EmailAddress]
        public string Email { get; set; }

        public string? Address { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(CompanyConstraints.PHONE_NUMBER_MAX_LENGTH)]
        public string PhoneNumber { get; set; } = null!;

        [Required] 
        public string Description { get; set; } = null!;
        
        public ICollection<Job> Jobs { get; set; }
    }
}
