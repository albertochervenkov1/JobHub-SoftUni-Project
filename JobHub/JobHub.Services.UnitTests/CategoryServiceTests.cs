using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobHub.Core.Contracts;
using JobHub.Core.Models.Category;
using JobHub.Core.Services;
using JobHub.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JobHub.Services.UnitTests
{
    [TestFixture]
    public class CategoryServiceTests:UnitTestBase
    {
        private ICategoryService categoryService;

        [SetUp]
        public void SetUp()
        {
            this.categoryService = new CategoryService(repo);
        }

        [Test]
        public async Task Test_GetAllCategories()
        {
            int dbCategoriesCount =repo.AllReadonly<Category>()
                .Count();

            var categories = await categoryService.GetAll();

            Assert.That(dbCategoriesCount,Is.EqualTo(categories.Count()));
        }

        [Test]
        public async Task Test_AddCategorySuccessfully()
        {
            int initialCategoryCount= repo.AllReadonly<Category>()
                .Count();

            var model = new CategoryViewModel()
            {
                Id = 3,
                Label = "Arts"
            };

            await categoryService.Add(model);

            int categoryCount= repo.AllReadonly<Category>()
                .Count();

            Assert.That(categoryCount, Is.EqualTo(initialCategoryCount + 1));

            var addedCategoryLabel = await repo.AllReadonly<Category>()
                .OrderByDescending(c => c.Id)
                .Select(c => c.Label)
                .FirstOrDefaultAsync();

            Assert.That(addedCategoryLabel, Is.EqualTo(model.Label));

        }

        [Test]
        public async Task Test_DeleteCategorySuccessfully()
        {
            var model = new CategoryViewModel()
            {
                Id = 3,
                Label = "Arts"
            };

            await categoryService.Add(model);

            int initialCategoryCount = repo.AllReadonly<Category>()
                .Count();

            await categoryService.Delete(model.Id);

            var categoryCountAfterDelete= repo.AllReadonly<Category>()
                .Count();

            Assert.That(initialCategoryCount-1,Is.EqualTo(categoryCountAfterDelete));
        }

       
    }
}
