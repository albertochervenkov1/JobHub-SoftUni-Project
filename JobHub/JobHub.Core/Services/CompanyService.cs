using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobHub.Core.Contracts;
using JobHub.Core.Models.Category;
using JobHub.Infrastructure.Data.Common;
using JobHub.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JobHub.Core.Services
{
    public class CompanyService:ICompanyService
    {
        private readonly IRepository repo;

        public CompanyService(IRepository _repo)
        {
            repo=_repo;
        }

        public async Task Create(AddCompanyViewModel model)
        {
            var company = new Company()
            {
                Name = model.Name,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber,
                Description = model.Description,
                UserId = model.UserId
            };

            await repo.AddAsync(company);
            await repo.SaveChangesAsync();
        }

        public async Task<bool> ExistsById(string userId)
        {
            return await repo.All<Company>()
                .AnyAsync(c => c.UserId == userId);
        }

        public async Task<bool> UserWithPhoneNumberExists(string phoneNumber)
        {
            return await repo.All<Company>()
                .AnyAsync(c => c.PhoneNumber == phoneNumber);
        }
    }
}
