using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobHub.Core.Models.Category;

namespace JobHub.Core.Contracts
{
    public  interface ICategoryService
    {
        /// <summary>
        /// Gets all products
        /// </summary>
        /// <returns>List of products</returns>
        Task<IEnumerable<CategoryViewModel>> GetAll();
        Task Add(CategoryViewModel categoryViewModel);

        Task Delete(int id);
    }
}
