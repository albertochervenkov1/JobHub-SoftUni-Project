using JobHub.Infrastructure.Data;
using JobHub.Infrastructure.Data.Common;
using JobHub.Services.UnitTests.Mocks;
using JobHub.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobHub.Services.UnitTests
{
    public class UnitTestBase
    {
        protected JobHubTestDb testDb;
        private ApplicationDbContext dbContext;
        protected IRepository repo;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbContext = DatabaseMock.Instance;
            this.testDb = new JobHubTestDb(this.dbContext);
            this.repo = new RepositoryMock(this.dbContext);
            
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            this.dbContext.Dispose();
        }
    }    
}
