using JobHub.Infrastructure.Data;
using JobHub.Infrastructure.Data.Common;
using JobHub.Services.UnitTests.Mocks;
using JobHub.Tests.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobHub.Infrastructure.Data.Models;
using Moq;

namespace JobHub.Services.UnitTests
{
    public class UnitTestBase
    {
        protected JobHubTestDb testDb;
        private ApplicationDbContext dbContext;
        protected IRepository repo;
        protected Mock<UserManager<User>> userManager;
        protected Mock<SignInManager<User>> signInManager;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbContext = DatabaseMock.Instance;
            this.testDb = new JobHubTestDb(this.dbContext);
            this.repo = new RepositoryMock(this.dbContext);
            this.userManager = UserManagerMock.MockUserManager(new List<User>
            {
                this.testDb.User,
            });

        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            this.dbContext.Dispose();
        }
    }    
}
