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
using Microsoft.Extensions.Configuration;

namespace JobHub.Core.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly IRepository repo;

        /// <summary>
        /// IoC 
        /// </summary>
        /// <param name="_config">Application configuration</param>
        public CategoryService(IRepository _repo)
        {
            repo = _repo;
        }
        
        public async Task<IEnumerable<CategoryViewModel>> GetAll()
        {
            /// <summary>
            /// Gets all categories
            /// </summary>
            /// <returns>List of categories</returns>
            return await repo.AllReadonly<Category>()
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Label = c.Label
                }).ToListAsync();
        }

        public async Task Add(CategoryViewModel categoryViewModel)
        {
            var category = new Category()
            {
                Label = categoryViewModel.Label
            };

            await repo.AddAsync(category);
            await repo.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var category = await repo.All<Category>()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (category != null)
            {
                await repo.DeleteAsync<Category>(category.Id);
                await repo.SaveChangesAsync();
            }
        }
    }
}
