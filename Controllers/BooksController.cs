using Microsoft.AspNetCore.Mvc;
using WEBAPP_ANGULAR_DOTNET.Data.Models;
using WEBAPP_ANGULAR_DOTNET.Data.Services;

namespace WEBAPP_ANGULAR_DOTNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController(IBookService bookService) : ControllerBase
    {
        private readonly IBookService _bookService = bookService;

        //Create or Add a new Book
        [HttpPost("AddBook")]
        public IActionResult AddBook([FromBody] Book book)
        {
            ObjectResult result;
            try
            {
                _bookService.AddBook(book);
                var response = new { message = "Book added successfully" };
                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = StatusCode(500, new { error = ex.Message });
            }
            return result;
        }

        //Read all books
        [HttpGet("[action]")]
        public IActionResult GetBooks()
        {
            ObjectResult result;
            try
            {
                var allBooks = _bookService.GetALLBooks();
                result = Ok(allBooks);
            }
            catch (Exception ex)
            {
                result = StatusCode(500, ex.Message);
            }
            return result;
        }

        //Update an exsisting book
        [HttpPut("UpdateBook/{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book book)
        {
            ObjectResult result;
            try
            {
                _bookService.UpdateBook(id, book);
                var response = new {message = $"Update {book.Title} successfully"};
                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = StatusCode(500, ex.Message);
            }
            return result;
        }

        //Delete an exsisting book
        [HttpDelete("DeleteBook/{id}")]
        public IActionResult DeleteBook(int id)
        {
            ObjectResult result;
            try
            {
                _bookService.DeleteBook(id);
                var response = new {message = $"Book with ID {id} deleted successfully"};
                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = StatusCode(500, ex.Message);
            }
            return result;
        }

        //Get a single book by ID
        [HttpGet("GetSingleBook/{id}")]
        public IActionResult GetBookById(int id)
        {
            ObjectResult result;
            try
            {
                var book = _bookService.GetBookById(id);
                result = Ok(book);
            }
            catch (Exception ex)
            {
                result = StatusCode(500, ex.Message);
            }
            return result;
        }
    }
}