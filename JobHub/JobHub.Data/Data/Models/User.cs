using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobHub.Infrastructure.Common;
using Microsoft.AspNetCore.Identity;

namespace JobHub.Infrastructure.Data.Models
{
    public class User:IdentityUser
    {
        [StringLength(UserConstraints.FIRST_NAME_MAX_LENGTH)] 
        public string FirstName { get; set; } = null!;

        [StringLength(UserConstraints.LAST_NAME_MAX_LENGTH)]
        public string LastName { get; set; } = null!;

        public ICollection<UserCompany> UserCompanies { get; set; } = new List<UserCompany>();
    }
}
