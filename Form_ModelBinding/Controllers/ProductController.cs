using Form_ModelBinding.Data;
using Form_ModelBinding.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Form_ModelBinding.Controllers
{

    public class ProductController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public ProductController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var products = dbContext.products.OrderByDescending(p => p.Id).ToList();
            return View(products);

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);

            }
            dbContext.products.Add(product);
            dbContext.SaveChanges();

            return RedirectToAction("Index", "Product");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = dbContext.products.Find(id);
            if (product == null) {
                return RedirectToAction("Index", "Product");
            }

            return View(product);
         
        }
        [HttpPost]
        public IActionResult Edit(Product viewModel) {
        var product = dbContext.products.Find(viewModel.Id);
            if (product is not null) {
                
                product.Name = viewModel.Name;
                product.Description = viewModel.Description;
                product.Price = viewModel.Price;
                dbContext.SaveChanges();
            }
            return RedirectToAction("Index", "Product");
        }

        public IActionResult Delete(int id) {
            var products = dbContext.products.Find(id);
            if (products != null)
            {
                dbContext.products.Remove(products);
                dbContext.SaveChanges();
              
            }
            return RedirectToAction("Index", "Product");
        }

    }
}
