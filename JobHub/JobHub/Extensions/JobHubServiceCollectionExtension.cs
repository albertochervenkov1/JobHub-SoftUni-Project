using JobHub.Core.Contracts;
using JobHub.Core.Services;
using JobHub.Infrastructure.Data.Common;

namespace JobHub.Extensions
{
    public static class JobHubServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IJobService, JobService>();
            services.AddScoped<IFileService, FileService>();


            return services;
        }
    }
}
