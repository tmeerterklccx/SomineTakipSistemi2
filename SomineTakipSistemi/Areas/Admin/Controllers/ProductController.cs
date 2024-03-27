using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace SomineTakipSistemi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var values = _productService.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Add(Product product)
        {
            _productService.TInsert(product);
            return RedirectToAction("Index", "Product", "Admin");
        }
        public IActionResult Delete(int id)
        {
            var value = _productService.TGetByID(id);
            _productService.TDelete(value);
            return RedirectToAction("Index", "Product", "Admin");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = _productService.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Update(int id, Product product)
        {
            var value = _productService.TGetByID(id);
            value.ProductName = product.ProductName;
            value.ProductImageLink = product.ProductImageLink;
            value.ProductDescription = product.ProductDescription;
            _productService.TUpdate(value);
            return RedirectToAction("Index", "Product", "Admin");
        }
    }
}
