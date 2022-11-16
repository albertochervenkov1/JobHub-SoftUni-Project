using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobHub.Core.Models.Category;

namespace JobHub.Core.Contracts
{
    public interface ICompanyService
    {
        Task Create(AddCompanyViewModel model);
        Task<bool> ExistsById(string userId);
        Task<bool> UserWithPhoneNumberExists(string phoneNumber);
    }
}
