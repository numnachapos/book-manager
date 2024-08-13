using WEBAPP_ANGULAR_DOTNET.Data.Models;
using WEBAPP_ANGULAR_DOTNET.Data.Models.Categories;

namespace WEBAPP_ANGULAR_DOTNET.Data
{
    public static class Data
    {
        public static List<Book> Books => allBooks;

        static readonly List<Book> allBooks =
        [
            new BiographyBook()
            {
                Id = 1,
                Title = "Steve Jobs",
                Description = "A biography of Steve Jobs, the co-founder of Apple Inc.",
                Author = "Walter Isaacson",
                Rate = 4.9,
                DateStart = new DateTime(2021, 01, 20).ToUniversalTime(),
                DateRead = new DateTime(2021, 02, 20).ToUniversalTime(),
                DateEnd = new DateTime(2021, 03, 20).ToUniversalTime(),
                Subject = "Steve Jobs",
                TimePeriod = "1955-2011",
                Publisher = new Publisher { PublisherId = 1, Name = "Simon & Schuster" }
            },
            new CryptoCurrencyBook()
            {
                Id = 2,
                Title = "Mastering Bitcoin",
                Description = "Unlocking Digital Cryptocurrencies.",
                Author = "Andreas M. Antonopoulos",
                Rate = 4.8,
                DateStart = new DateTime(2021, 04, 10).ToUniversalTime(),
                DateRead = new DateTime(2021, 05, 10).ToUniversalTime(),
                DateEnd = new DateTime(2021, 06, 10).ToUniversalTime(),
                CurrencyType = "Bitcoin",
                MarketTrend = "Bullish",
                Publisher = new Publisher { PublisherId = 2, Name = "O'Reilly Media" }
            },
            new InvestmentBook()
            {
                Id = 3,
                Title = "The Intelligent Investor",
                Description = "The definitive book on value investing.",
                Author = "Benjamin Graham",
                Rate = 4.7,
                DateStart = new DateTime(2021, 07, 15).ToUniversalTime(),
                DateRead = new DateTime(2021, 08, 15).ToUniversalTime(),
                DateEnd = new DateTime(2021, 09, 15).ToUniversalTime(),
                InvestmentType = "Stocks",
                Strategy = "Value Investing",
                Publisher = new Publisher { PublisherId = 3, Name = "HarperCollins" }
            }
        ];

         public static void SeedData(AppDbContext context)
        {
            if (!context.Set<Book>().Any())
            {
                context.Set<Book>().AddRange(allBooks);
                context.SaveChanges();
            }
        }
    }
}