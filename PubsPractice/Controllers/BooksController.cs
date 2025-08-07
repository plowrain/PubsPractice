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
            try
            {
                var data = _pubsAccess.GetBook();
                if (data.Count() != 0)
                {
                    return Json(data);

                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Index(string id)
        {
            try
            {
                var data = _pubsAccess.GetBook(id);
                if (data != null)
                {
                    return Json(data);

                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            try
            {
                _pubsAccess.DeleteTitle(id);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(string id)
        {
            try
            {
                //_pubsAccess.CreateTitle(id);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(string id)
        {
            try
            {
                //_pubsAccess.UpdateTitle(id);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest(ex.Message);
            }
        }
    }
}
