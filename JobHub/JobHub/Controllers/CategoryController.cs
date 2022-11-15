using JobHub.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using JobHub.Core.Models.Category;

namespace JobHub.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var products = await categoryService.GetAll();
            ViewData["Title"] = "Categories";

            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new CategoryViewModel();
            ViewData["Title"] = "Add new category";

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryViewModel model)
        {
            ViewData["Title"] = "Add new category";

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await categoryService.Add(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await categoryService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
