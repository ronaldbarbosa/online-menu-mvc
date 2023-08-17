using Microsoft.AspNetCore.Mvc;
using OnlineMenu.Models;
using OnlineMenu.Models.ViewModels;
using OnlineMenu.Services;

namespace OnlineMenu.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductsService _productsService;
        private readonly CategoriesService _categoriesService;

        public ProductsController(ProductsService productsService, CategoriesService categoriesService)
        {
            _productsService = productsService;
            _categoriesService = categoriesService;
        }

        public async Task<ActionResult> Index()
        {
            var products = await _productsService.GetProductsAsync();
            return View(products);
        }

        public async Task<ActionResult> Details(Guid id)
        {
            var product = await _productsService.GetProductAsync(id);
            if (product != null)
            {
                return View(product);
            }
            return NotFound();
        }

        public async Task<ActionResult> Create()
        {
            var categories = await _categoriesService.GetCategoriesAsync();
            var viewModel = new ProductFormViewModel { Categories = categories };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Product product)
        {
            product.Category = await _categoriesService.GetCategoryAsync(product.CategoryId);

            await _productsService.CreateProductAsync(product);
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            var product = await _productsService.GetProductAsync(id);
            var categories = await _categoriesService.GetCategoriesAsync();
            var viewModel = new ProductFormViewModel { Id = product.Id, Product = product, Categories = categories };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, Product product)
        {
            await _productsService.UpdateProductAsync(product);
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Delete(Guid id)
        {
            var product = await _productsService.GetProductAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Product product)
        {
            await _productsService.DeleteProductAsync(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
