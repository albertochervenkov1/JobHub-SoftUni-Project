using JobHub.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobHub.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        private readonly bool isSeed;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,bool isSeed=true)
            : base(options)
        {
            this.isSeed = isSeed;
        }

        public DbSet<Company> Companies { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Job> Jobs { get; set; } = null!;
        public DbSet<CvFile> Files { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserCompany>()
                .HasKey(x => new
                {
                    x.UserId,
                    x.CompanyId
                });
            

            base.OnModelCreating(builder);
        }
    }
}