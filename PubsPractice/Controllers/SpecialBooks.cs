using PubsPractice.Database;
using PubsPractice.ServiceLayer.BooksService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PubsPractice.Controllers
{
    public class SpecialBooks : Controller
    {
        private readonly ILogger<SpecialBooks> _logger;
        private readonly IPubsAccess _pubsAccess;
        private readonly IBookService _bookService;

        public SpecialBooks(ILogger<SpecialBooks> logger,
                              IPubsAccess pubsAccess,
                              IBookService bookService)
        {
            _logger = logger;
            _pubsAccess = pubsAccess;
            _bookService = bookService;
        }

        //public IActionResult GetFilterBooks()
        //{
        //    //

        //}
    }
}
