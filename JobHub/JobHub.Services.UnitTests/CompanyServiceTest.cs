using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using JobHub.Core.Contracts;
using JobHub.Core.Models.Company;
using JobHub.Core.Models.Job;
using JobHub.Core.Services;
using JobHub.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JobHub.Services.UnitTests
{
    [TestFixture]
    public class CompanyServiceTest:UnitTestBase
    {
        private ICompanyService companyService;

        [SetUp]
        public void SetUp()
        {
            companyService = new CompanyService(repo);
        }

        [Test]
        public async Task Test_CheckIfPhoneNumberExists()
        {
            var phoneNumber = "+359898888888";

            var result = await companyService.UserWithPhoneNumberExists(phoneNumber);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task Test_GetCompanyDetailsById()
        {
            var id = 2;

            var model = await companyService.CompanyDetailsById(id);

            Company company = await repo.GetByIdAsync<Company>(id);

            Assert.That(id, Is.EqualTo(model.Id));

            Assert.That(company, Is.Not.Null);
            Assert.That(company.Name, Is.EqualTo(model.Name));
            Assert.That(company.Description, Is.EqualTo(model.Description));
            Assert.That(company.City, Is.EqualTo(model.City));
            Assert.That(company.Email, Is.EqualTo(model.Email));
            Assert.That(company.PhoneNumber, Is.EqualTo(model.PhoneNumber));
        }

        [Test]
        public async Task Test_EditCompany_ChangesSuccessfully()
        {
            var companyId = 2;

            var model = new CompanyViewModel()
            {
                Name = "New Company Name",
                Description = "New Company Description",
                City = "New Company City",
                PhoneNumber = "+359897777777",
                Email = "company3333@example.com"
            };

            await companyService.Edit(companyId, model);

            Company company = await repo.GetByIdAsync<Company>(companyId);

            Assert.That(company, Is.Not.Null);
            Assert.That(company.Name, Is.EqualTo(model.Name));
            Assert.That(company.Description, Is.EqualTo(model.Description));
            Assert.That(company.City, Is.EqualTo(model.City));
            Assert.That(company.Email, Is.EqualTo(model.Email));
            Assert.That(company.PhoneNumber, Is.EqualTo(model.PhoneNumber));
        }

        [Test]
        public async Task Test_CheckIfCompanyExists()
        {
            var companyId = 2;

            var result = await companyService.CompanyExists(companyId);

            Assert.That(result,Is.True);
        }
    }
}
