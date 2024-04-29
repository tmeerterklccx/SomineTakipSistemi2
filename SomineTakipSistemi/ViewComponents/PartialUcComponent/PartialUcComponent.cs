using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace SomineTakipSistemi.ViewComponents.PartialUcComponent
{
    public class PartialUcComponent : ViewComponent
    {
        private readonly IProductService _productService;

        public PartialUcComponent(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _productService.TGetList();
            return View(values);
        }
    }
}
