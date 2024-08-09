using WEBAPP_ANGULAR_DOTNET.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace WEBAPP_ANGULAR_DOTNET.Data
{
    public static class Data
    {
        public static List<Book> Books => allBooks;

        static List<Book> allBooks = new()
        {
            new Book()
            {
                Id = 1,
                Title="The Lean Startup",
                Description="Most startups fail. But many of those failures are preventable. The Lean Startup is a new approach to business that's being adopted around the world. It is changing the way companies are built and new products are launched.",
                Author="Eric Ries",
                Rate= 4.9,
                DateStart = new DateTime(2020, 01, 20).ToUniversalTime(),
                DateRead = null,
                DateEnd = null
            },
            new Book()
            {
                Id = 2,
                Title="Atomic Habits",
                Description="No matter your goals, Atomic Habits offers a proven framework for improving--every day.",
                Author="James Clear",
                Rate= 4.8,
                DateStart = null,
                DateRead = null
            },
            new Book()
            {
                Id = 3,
                Title="The Psychology of Money",
                Description="Timeless lessons on wealth, greed, and happiness doing well with money isn’t necessarily about what you know. It’s about how you behave.",
                Author="Morgan Housel",
                Rate= 4.4,
                DateStart = new DateTime(2020, 02, 18).ToUniversalTime(),
                DateRead = new DateTime(2020, 02, 19).ToUniversalTime()
            },
            new Book()
            {
                Id = 4,
                Title="Zero to One",
                Description="Zero to One presents at once an optimistic view of the future of progress in America and a new way of thinking about innovation: it starts by learning to ask the questions that lead you to find value in unexpected places.",
                Author="Peter Thiel",
                Rate= 4.7,
                DateStart = new DateTime(2020, 02, 18).ToUniversalTime(),
                DateEnd = new DateTime(2020, 02, 28).ToUniversalTime()
            }
        };

        public static void SeedData(DbContext context)
        {
            if (!context.Set<Book>().Any())
            {
                context.Set<Book>().AddRange(allBooks);
                context.SaveChanges();
            }
        }
    }
}