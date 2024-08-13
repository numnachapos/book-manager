using Microsoft.EntityFrameworkCore;
using WEBAPP_ANGULAR_DOTNET.Data.Models;

namespace WEBAPP_ANGULAR_DOTNET.Data.Services
{
    public class PublisherService(AppDbContext context) : IPublisherService
    {
        private readonly AppDbContext _context = context;

        public async Task AddPublisher(Publisher publisher)
        {
            await _context.Publishers.AddAsync(publisher);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePublisher(int id, Publisher publisher)
        {
            var existingPublisher = await _context.Publishers.FindAsync(id);
            if (existingPublisher != null)
            {
                existingPublisher.Name = publisher.Name;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeletePublisher(int id)
        {
            var publisher = await _context.Publishers.FindAsync(id);
            if (publisher != null)
            {
                _context.Publishers.Remove(publisher);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Publisher?> GetPublisherById(int id)
        {
            return await _context.Publishers.FindAsync(id);
        }

        public async Task<IEnumerable<Publisher>> GetAllPublishers()
        {
            return await _context.Publishers.ToListAsync();
        }
    }
}