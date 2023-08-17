using Microsoft.AspNetCore.Mvc;
using OnlineMenu.Models;
using OnlineMenu.Services;

namespace OnlineMenu.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly CategoriesService _categoriesService;
        public CategoriesController(CategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        public async Task<ActionResult> Index()
        {
            var categories = await _categoriesService.GetCategoriesAsync();
            return View(categories);
        }

        public async Task<ActionResult> Details(Guid id)
        {
            var category = await _categoriesService.GetCategoryAsync(id);
            if (category != null)
            {
                return View(category);
            }
            return NotFound();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                await _categoriesService.CreateCategoryAsync(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            var category = await _categoriesService.GetCategoryAsync(id);
            if (category != null)
            {
                return View(category);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                await _categoriesService.UpdateCategoryAsync(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public async Task<ActionResult> Delete(Guid id)
        {
            var category = await _categoriesService.GetCategoryAsync(id);
            if (category != null) 
            {
                return View(category);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Category category)
        {
            await _categoriesService.DeleteCategoryAsync(category);
            return RedirectToAction(nameof(Index));
        }
    }
}
