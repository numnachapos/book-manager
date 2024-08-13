using WEBAPP_ANGULAR_DOTNET.Data.Models;

namespace WEBAPP_ANGULAR_DOTNET.Data.Services
{
    public interface IPublisherService
    {
        Task AddPublisher(Publisher publisher);
        Task UpdatePublisher(int id, Publisher publisher);
        Task DeletePublisher(int id);
        Task<Publisher?> GetPublisherById(int id);
        Task<IEnumerable<Publisher>> GetAllPublishers();
    }
}