using Microsoft.AspNetCore.Mvc;
using PubsPractice.Database;

namespace PubsPractice.Controllers
{
    public class BooksController : Controller
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IPubsAccess _pubsAccess;

        public BooksController(ILogger<BooksController> logger,
                              IPubsAccess pubsAccess)
        {
            _logger = logger;
            _pubsAccess = pubsAccess;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var data = _pubsAccess.GetBook();
            return Json(data);
        }

        [HttpGet]
        public IActionResult Index(string id)
        {
            var data = _pubsAccess.GetBook(id);
            return Json(data);
        }


    }
}
