using Microsoft.EntityFrameworkCore;
using WEBAPP_ANGULAR_DOTNET.Data.Models;

namespace WEBAPP_ANGULAR_DOTNET.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Book> Books { get; set; }
    }
}