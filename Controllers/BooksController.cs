using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WEBAPP_ANGULAR_DOTNET.Data;
using WEBAPP_ANGULAR_DOTNET.Data.Models;
using WEBAPP_ANGULAR_DOTNET.Data.Services;
using WEBAPP_ANGULAR_DOTNET.Data.Models.Enum;


namespace WEBAPP_ANGULAR_DOTNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController(IBookService bookService, AppDbContext context, ILogger<BooksController> logger) : ControllerBase
    {
        private readonly IBookService _bookService = bookService;
        private readonly AppDbContext _context = context;
        private readonly ILogger _logger = logger;

        // Create or Add a new Book
        [HttpPost("AddBook")]
        public async Task<IActionResult> AddBook([FromBody] Book book)
        {
            try
            {
                await _bookService.AddBook(book);
                var response = new { message = "Book added successfully" };
                _logger.LogInformation("Adding book: {book}", response);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error adding book: {error}", ex.Message);
                return StatusCode(500, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Retrieves a list of books based on the specified book type.
        /// </summary>
        /// <param name="bookType">The type of book to filter by.</param>
        /// <returns>An ActionResult containing a list of books.</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks([FromQuery] BookTypes? bookType)
        {
            try
            {
                var books = _context.Books.AsQueryable();
            if (bookType.HasValue)
            {
                books = books.Where(b => b.BookType == bookType.Value);
            }
            _logger.LogInformation("Getting books: {books}", books.ToList());
            return Ok(books.ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError("Error getting books: {error}", ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Retrieves a list of books based on the specified book type asynchronously.
        /// </summary>
        /// <param name="bookType">The type of book to filter by.</param>
        /// <returns>An ActionResult containing a list of books.</returns>
        [HttpGet("GetBooksByType")]
        public async Task<IActionResult> GetBooksByType([FromQuery] BookTypes bookType)
        {
            try
            {
                var books = await _bookService.GetBooksByTypeAsync(bookType);
                _logger.LogInformation("Getting books by type: {books}", books);
                return Ok(books);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error getting books by type: {error}", ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("types")]
        public ActionResult<IEnumerable<string>> GetBookTypes()
        {
            try
            {
                var BookTypeslist = Enum.GetNames(typeof(BookTypes)).ToList();
                _logger.LogInformation("Getting book types: {BookTypeslist}", BookTypeslist);
                return Ok(BookTypeslist);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error getting book types: {error}", ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        // Update an existing book
        [HttpPut("UpdateBook/{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] Book book)
        {
            try
            {
                await _bookService.UpdateBook(id, book);
                var response = new { message = $"Update {book.Title} successfully" };
                _logger.LogInformation("Updating book: {book}", response);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error updating book: {error}", ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        // Delete an existing book
        [HttpDelete("DeleteBook/{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                await _bookService.DeleteBook(id);
                var response = new { message = $"Book with ID {id} deleted successfully" };
                _logger.LogInformation("Deleting book: {response}", response);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error deleting book: {error}", ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        // Get a single book by ID
        [HttpGet("GetSingleBook/{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            try
            {
                var book = await _bookService.GetBookById(id);
                _logger.LogInformation("Getting book by ID: {book}", book);
                return Ok(book);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error getting book by ID: {error}", ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}