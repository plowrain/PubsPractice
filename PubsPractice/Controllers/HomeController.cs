using Microsoft.AspNetCore.Mvc;
using PubsPractice.Database;
using PubsPractice.Models;
using System.Diagnostics;

namespace PubsPractice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPubsAccess _pubsAccess;

        public HomeController(ILogger<HomeController> logger,
                              IPubsAccess pubsAccess)
        {
            _logger = logger;
            _pubsAccess = pubsAccess;
        }

        public IActionResult Index()
        {
            //_pubsAccess.GetTestDatabase();
            var data = _pubsAccess.GetBook();
            // 使用 Guid.NewGuid() 進行隨機排序，並取前三筆
            var randomBooks = data.OrderBy(b => Guid.NewGuid()).Take(3).ToList(); 
            return View(randomBooks);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}