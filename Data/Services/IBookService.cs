using WEBAPP_ANGULAR_DOTNET.Data.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WEBAPP_ANGULAR_DOTNET.Data.Services
{
    public interface IBookService
    {
        Task<List<Book>> GetALLBooks();

        Task<Book?> GetBookById(int id);

        Task UpdateBook(int id, Book newBook);

        Task DeleteBook(int id);

        Task AddBook(Book newBook);
    }
}