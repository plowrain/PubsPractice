using PubsPractice.Database;
using PubsPractice.Models;
using System;

namespace PubsPractice.ServiceLayer.BooksService
{
    public class BookService : IBookService
    {
        private readonly IPubsAccess _pubsAccess;

        public BookService(IPubsAccess pubsAccess)
        {
            _pubsAccess = pubsAccess;
        }

        public ErrorViewModel CreateBook(Title title)
        {
            ErrorViewModel errorViewModel = new ErrorViewModel();

            if (string.IsNullOrWhiteSpace(title.TitleId))
            {
                errorViewModel.SetMsg("2", "ID不可為空白");
                return errorViewModel;
            }
            var books = _pubsAccess.GetBook(title.TitleId);

            try
            {
                if (books == null)
                {
                    _pubsAccess.CreateTitle(books);
                    errorViewModel.SetMsg("1");
                    return errorViewModel;
                }
                else
                {
                    errorViewModel.SetMsg("2", "該書已存在");
                    return errorViewModel;
                }
            }
            catch (Exception ex)
            {
                errorViewModel.SetMsg("4", ex.Message);
                return errorViewModel;
            }
        }

        public ErrorViewModel UpdateBook(Title title)
        {
            ErrorViewModel errorViewModel = new ErrorViewModel();

            if (string.IsNullOrWhiteSpace(title.TitleId))
            {
                errorViewModel.SetMsg("2", "ID不可為空白");
                return errorViewModel;
            }
            var books = _pubsAccess.GetBook(title.TitleId);

            try
            {
                if (books != null)
                {
                    books.Title1 = title.Title1;
                    books.Type = title.Type;
                    books.PubId = title.PubId;
                    books.Price = title.Price;
                    books.Advance = title.Advance;
                    books.Royalty = title.Royalty;
                    books.YtdSales = title.YtdSales;
                    books.Notes = title.Notes;
                    books.Pubdate = title.Pubdate;

                    _pubsAccess.UpdateTitle(books);
                    errorViewModel.SetMsg("1");
                    return errorViewModel;
                }
                else
                {
                    errorViewModel.SetMsg("2", "該書不存在");
                    return errorViewModel;
                }
            }
            catch (Exception ex)
            {
                errorViewModel.SetMsg("4", ex.Message);
                return errorViewModel;
            }
        }

        public ErrorViewModel DeleteBook(string id)
        {
            var books = _pubsAccess.GetBook(id);
            try
            {
                ErrorViewModel errorViewModel = new ErrorViewModel();
                if (books != null)
                {
                    _pubsAccess.DeleteTitle(books);
                    errorViewModel.SetMsg("1");
                    return errorViewModel;
                }
                else
                {
                    errorViewModel.SetMsg("3");
                    return errorViewModel;
                }
            }
            catch (Exception ex)
            {
                ErrorViewModel errorViewModel = new ErrorViewModel("4");
                errorViewModel.ErrorMsg = ex.Message;
                return errorViewModel;
            }

        }
    }
}
