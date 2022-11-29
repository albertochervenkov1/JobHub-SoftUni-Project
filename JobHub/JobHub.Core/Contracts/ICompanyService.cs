using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobHub.Core.Models.Company;

namespace JobHub.Core.Contracts
{
    public interface ICompanyService
    {
        Task Create(AddCompanyViewModel model,string userId);
        Task<bool> UserWithPhoneNumberExists(string phoneNumber);
        Task<IEnumerable<CompanyViewModel>> GetMineAsync(string userId);
        Task<CompanyViewModel> CompanyDetailsById(int id);
        Task Edit(int id, CompanyViewModel model);
    }
}
