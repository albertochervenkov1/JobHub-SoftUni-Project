using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobHub.Infrastructure.Data.Models
{
    public class UserCompany
    {
        [Required] 
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))] 
        public User User { get; set; } = null!;

        public int CompanyId { get; set; }
        [ForeignKey(nameof(CompanyId))] 
        public Company Company { get; set; }

    }
}
