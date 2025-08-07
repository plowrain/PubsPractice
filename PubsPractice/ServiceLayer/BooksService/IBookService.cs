using PubsPractice.Models;

namespace PubsPractice.ServiceLayer.BooksService
{
    public interface IBookService
    {
        ErrorViewModel UpdateBook(Title title);
        ErrorViewModel CreateBook(Title title);
        ErrorViewModel DeleteBook(string id);
    }
}
