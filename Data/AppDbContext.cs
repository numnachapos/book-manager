using Microsoft.EntityFrameworkCore;
using WEBAPP_ANGULAR_DOTNET.Data.Models;
using WEBAPP_ANGULAR_DOTNET.Data.Models.Categories;

namespace WEBAPP_ANGULAR_DOTNET.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<BiographyBook> BiographyBooks { get; set; }
        public DbSet<CryptoCurrencyBook> CryptoCurrencyBooks { get; set; }
        public DbSet<InvestmentBook> InvestmentBooks { get; set; }
    }
}