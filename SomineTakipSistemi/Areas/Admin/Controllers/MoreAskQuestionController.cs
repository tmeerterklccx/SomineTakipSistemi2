using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace SomineTakipSistemi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MoreAskQuestionController : Controller
    {
        private readonly IMoreAskQuestionService _moreAskQuestionService;

        public MoreAskQuestionController(IMoreAskQuestionService moreAskQuestionService)
        {
            _moreAskQuestionService = moreAskQuestionService;
        }

        public IActionResult Index()
        {
            var values = _moreAskQuestionService.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Add(MoreAskQuestion moreAskQuestion)
        {
            _moreAskQuestionService.TInsert(moreAskQuestion);
            return RedirectToAction("Index", "MoreAskQuestion", "Admin");
        }
        public IActionResult Delete(int id)
        {
            var value = _moreAskQuestionService.TGetByID(id);
            _moreAskQuestionService.TDelete(value);
            return RedirectToAction("Index", "MoreAskQuestion", "Admin");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = _moreAskQuestionService.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Update(int id, MoreAskQuestion moreAskQuestion)
        {
            var value = _moreAskQuestionService.TGetByID(id);
            value.Answer = moreAskQuestion.Answer;
            value.Question = moreAskQuestion.Question;
            _moreAskQuestionService.TUpdate(value);
            return RedirectToAction("Index", "MoreAskQuestion", "Admin");
        }
    }
}
