using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace SomineTakipSistemi.ViewComponents.PartialIkiComponent
{
    public class PartialIkiComponent : ViewComponent
    {
        private readonly IOurInfoService _infoService;

        public PartialIkiComponent(IOurInfoService infoService)
        {
            _infoService = infoService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _infoService.TGetList();
            return View(values);
        }
    }
}
