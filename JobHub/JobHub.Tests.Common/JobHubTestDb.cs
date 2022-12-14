using JobHub.Infrastructure.Data;
using JobHub.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobHub.Tests.Common
{
    public  class JobHubTestDb
    {
        protected List<CvFile> list = new List<CvFile>();
        public JobHubTestDb(ApplicationDbContext dbContext)
        {
            SeedDatabase(dbContext);
        }

        public Company FirstCompany { get; set; } = null!;
        public Company SecondCompany { get; set; } = null!;

        public Category SoftwareCategory { get; set; } = null!;
        public Category DesignCategory { get; set; } = null!;

        public Job FirstJob { get; set; } = null!;
        public Job SecondJob { get; set; } = null!;
        public Job ThirdJob { get; set; } = null!;
        public User User { get; set; }
        private void SeedDatabase(ApplicationDbContext dbContext)
        {
            //UserOnlyStore<User, ApplicationDbContext, Guid> userStore =
            //    new UserOnlyStore<User, ApplicationDbContext, Guid>(dbContext);
            //PasswordHasher<User> hasher = new PasswordHasher<User>();
            //UpperInvariantLookupNormalizer normalizer = new UpperInvariantLookupNormalizer();
            //UserManager<User> userManager = new UserManager<User>(
            //    userStore,
            //    null,
            //    hasher,
            //    null, null,
            //    normalizer,
            //    null, null, null);


            //User = new User()
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    FirstName = "User First Name",
            //    LastName = "User Last Name",
            //    Email = "user@example.com",
            //    NormalizedEmail = "USER@EXAMPLE.COM",
            //};
            //userManager.CreateAsync(this.User, "guestPass")
            //    .Wait();
            SoftwareCategory = new Category
            {
                Id = 1,
                Label = "Software"
            };
            dbContext.Add(SoftwareCategory);
            DesignCategory = new Category
            {
                Id = 2,
                Label = "Design"
            };
            dbContext.Add(DesignCategory);

            FirstJob = new Job
            {
                Id = 1,
                Title = "First Job",
                City = "Sofia",
                Description = "First job description",
                Salary = 1000,
                CategoryId = SoftwareCategory.Id,
                Category = SoftwareCategory,
                CompanyId = 1,
                CreatedDate = DateTime.ParseExact(DateTime.Now.ToString(CultureInfo.InvariantCulture), "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                Files =list
            };
            dbContext.Add(FirstJob);

            SecondJob = new Job
            {
                Id = 2,
                Title = "Second Job",
                City = "Blagoevgrad",
                Description = "Second job description",
                Salary = 2000,
                CategoryId = DesignCategory.Id,
                Category = DesignCategory,
                CompanyId = 2,
                CreatedDate = DateTime.ParseExact(DateTime.Now.ToString(CultureInfo.InvariantCulture), "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                Files = list
            };

            dbContext.Add(SecondJob);

            ThirdJob = new Job
            {
                Id = 3,
                Title = "Third Job",
                City = "Varna",
                Description = "Third job description",
                Salary = 3000,
                CategoryId = DesignCategory.Id,
                Category = DesignCategory,
                CompanyId = 1,
                CreatedDate = DateTime.ParseExact(DateTime.Now.ToString(CultureInfo.InvariantCulture), "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture)
            };
            dbContext.Add(ThirdJob);
            

            

            this.FirstCompany = new Company
            {
                Id = 1,
                Name = "First Company",
                City = "Sofia",
                Description="First Company description",
                Email="company1@gmail.com",
                PhoneNumber="+359891111111",
                Jobs=new List<Job>() { FirstJob,ThirdJob}
            };
            dbContext.Add(this.FirstCompany);

            this.SecondCompany = new Company
            {
                Id = 2,
                Name = "Second Company",
                City = "Blagoevgrad",
                Description = "Second Company description",
                Email = "company2@gmail.com",
                PhoneNumber = "+359892222222",
                Jobs=new List<Job>() { SecondJob}
            };
            dbContext.Add(SecondCompany);

            
            dbContext.SaveChanges();
        }
    }
}
