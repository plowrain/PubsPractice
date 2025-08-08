using Microsoft.AspNetCore.Mvc;
using PubsPractice.Database;
using PubsPractice.Models;
using PubsPractice.ServiceLayer.BooksService;

namespace PubsPractice.Controllers
{
    public class BooksController : Controller
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IPubsAccess _pubsAccess;
        private readonly IBookService _bookService;

        public BooksController(ILogger<BooksController> logger,
                              IPubsAccess pubsAccess,
                              IBookService bookService)
        {
            _logger = logger;
            _pubsAccess = pubsAccess;
            _bookService = bookService;
        }

        public IActionResult List()
        {
            // 從資料庫取得所有書籍
            var books = _pubsAccess.GetBooksViewModels();
            return View(books);
        }

        public IActionResult Details(int id)
        {
            // 從資料庫取得單一書籍
            
            return View();
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
                _bookService.DeleteBook(id);
                
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(string titleId, string title1, string type,
                string pubId, decimal? price, decimal? advance, int? royalty,
                int? ytdSales, string notes, DateTime pubdate)
        {
            var _title = new Title()
            {
                TitleId = titleId,
                Title1 = title1,
                Type = type,
                PubId = pubId,
                Price = price,
                Advance = advance,
                Royalty = royalty,
                YtdSales = ytdSales,
                Notes = notes,
                Pubdate = pubdate
            };

            try
            {
                _bookService.CreateBook(_title);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(string titleId, string title1, string type,
                string pubId, decimal? price, decimal? advance, int? royalty,
                int? ytdSales, string notes, DateTime pubdate)
        {
            var _title = new Title()
            {
                TitleId = titleId,
                Title1 = title1,
                Type = type,
                PubId = pubId,
                Price = price,
                Advance = advance,
                Royalty = royalty,
                YtdSales = ytdSales,
                Notes = notes,
                Pubdate = pubdate
            };

            try
            {
                _bookService.UpdateBook(_title);
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
