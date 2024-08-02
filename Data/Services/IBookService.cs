using WEBAPP_ANGULAR_DOTNET.Data.Models;

namespace WEBAPP_ANGULAR_DOTNET.Data.Services
{
    public interface IBookService
    {
        List<Book> GetALLBooks();

        Book GetBookById(int id);

        void UpdateBook(int id, Book newBook);

        void DeleteBook(int id);

        void AddBook(Book newBook);
    }
}