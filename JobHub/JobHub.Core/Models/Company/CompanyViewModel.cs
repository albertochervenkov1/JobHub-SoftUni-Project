using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace JobHub.Core.Models.Company
{
    public class CompanyViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string City { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;

        public ICollection<Infrastructure.Data.Models.Job> Jobs { get; set; } =
            new List<Infrastructure.Data.Models.Job>();

    }
}
