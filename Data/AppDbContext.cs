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
        public DbSet<Publisher> Publishers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
                .Property(b => b.BookType)
                .HasConversion<int>();

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(b => b.PublisherId);
        }
    }
}