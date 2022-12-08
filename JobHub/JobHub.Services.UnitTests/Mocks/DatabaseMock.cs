using JobHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobHub.Services.UnitTests.Mocks
{
    public static class DatabaseMock
    {
        public static ApplicationDbContext Instance
        {
            get
            {
                DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder =
                       new DbContextOptionsBuilder<ApplicationDbContext>();

                optionsBuilder.UseInMemoryDatabase($"JobHun-TestDb-{DateTime.Now.Ticks}");

                return new ApplicationDbContext(optionsBuilder.Options,false);
            }
        }
    }
}
