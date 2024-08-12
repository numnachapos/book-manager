using Microsoft.EntityFrameworkCore;
using WEBAPP_ANGULAR_DOTNET.Data.Models;
using WEBAPP_ANGULAR_DOTNET.Data.Models.Categories;
using WEBAPP_ANGULAR_DOTNET.Data.Models.Enum;

namespace WEBAPP_ANGULAR_DOTNET.Data.Services
{
    public class BookService(AppDbContext context) : IBookService
    {
        private readonly AppDbContext _context = context;

        public async Task AddBook(Book newBook)
        {
            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if(book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Book>> GetALLBooks()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book?> GetBookById(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<List<object>> GetBooksByTypeAsync(BookTypes bookType)
        {
            return bookType switch
            {
                BookTypes.BiographyBook => await _context.BiographyBooks.Cast<object>().ToListAsync(),
                BookTypes.CryptoCurrencyBook => await _context.CryptoCurrencyBooks.Cast<object>().ToListAsync(),
                BookTypes.InvestmentBook => await _context.InvestmentBooks.Cast<object>().ToListAsync(),
                _ => [],
            };
        }

        public async Task UpdateBook(int id, Book newBook)
        {
            if (newBook != null)
            {
                var existingBook = await _context.Books.FindAsync(id);
                if (existingBook != null)
                {
                    // Update common properties
                    existingBook.Title = newBook.Title;
                    existingBook.Author = newBook.Author;
                    existingBook.Description = newBook.Description;
                    existingBook.BookType = newBook.BookType;
                    existingBook.Rate = newBook.Rate;
                    existingBook.DateStart = newBook.DateStart;
                    existingBook.DateRead = newBook.DateRead;
                    existingBook.DateEnd = newBook.DateEnd;

                    // Update specific properties based on book type
                    switch (newBook.BookType)
                    {
                        case BookTypes.BiographyBook:
                            if (existingBook is BiographyBook existingBiographyBook && newBook is BiographyBook newBiographyBook)
                            {
                                existingBiographyBook.Subject = newBiographyBook.Subject;
                                existingBiographyBook.TimePeriod = newBiographyBook.TimePeriod;
                                _context.BiographyBooks.Update(existingBiographyBook);
                            }
                            break;

                        case BookTypes.CryptoCurrencyBook:
                            if (existingBook is CryptoCurrencyBook existingCryptoBook && newBook is CryptoCurrencyBook newCryptoBook)
                            {
                                existingCryptoBook.CurrencyType = newCryptoBook.CurrencyType;
                                existingCryptoBook.MarketTrend = newCryptoBook.MarketTrend;
                                _context.CryptoCurrencyBooks.Update(existingCryptoBook);
                            }
                            break;

                        case BookTypes.InvestmentBook:
                            if (existingBook is InvestmentBook existingInvestmentBook && newBook is InvestmentBook newInvestmentBook)
                            {
                                existingInvestmentBook.InvestmentType = newInvestmentBook.InvestmentType;
                                existingInvestmentBook.Strategy = newInvestmentBook.Strategy;
                                _context.InvestmentBooks.Update(existingInvestmentBook);
                            }
                            break;
                    }

                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new KeyNotFoundException("Book not found");
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(newBook));
            }
        }
    }
}