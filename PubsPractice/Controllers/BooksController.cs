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
            _pubsAccess.GetTestDatabase();
            return View();
        }

    }
}
