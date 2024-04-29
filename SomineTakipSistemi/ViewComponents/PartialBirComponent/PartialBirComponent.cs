using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace SomineTakipSistemi.ViewComponents.PartialBirComponent
{
    public class PartialBirComponent : ViewComponent
    {
        private readonly IMainTopService _mainTopService;

        public PartialBirComponent(IMainTopService mainTopService)
        {
            _mainTopService = mainTopService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _mainTopService.TGetList();
            return View(values);
        }
    }
}
