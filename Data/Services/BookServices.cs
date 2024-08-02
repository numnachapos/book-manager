using WEBAPP_ANGULAR_DOTNET.Data.Models;

namespace WEBAPP_ANGULAR_DOTNET.Data.Services
{
    public class BookService : IBookService
    {
        public void AddBook(Book newBook)
        {
            Data.Books.Add(newBook);
        }

        public void DeleteBook(int id)
        {
            var booktoDelete = GetExistingBook(id);
            Data.Books.Remove(booktoDelete);
        }

        public List<Book> GetALLBooks()
        {
            return Data.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            return GetExistingBook(id);
        }

        public void UpdateBook(int id, Book newBook)
        {
            var oldBook = GetExistingBook(id);
            oldBook.Title = newBook.Title;
            oldBook.Author = newBook.Author;
            oldBook.Description = newBook.Description;
            oldBook.Rate = newBook.Rate;
            oldBook.DateStart = newBook.DateStart;
            oldBook.DateRead = newBook.DateRead;
            oldBook.DateEnd = newBook.DateEnd;
        }

        private static Book GetExistingBook(int id)
        {
            return Data.Books.FirstOrDefault(n => n.Id == id) ?? throw new Exception("The book is not found");
        }
    }
}