using Microsoft.AspNetCore.Mvc;
using WEBAPP_ANGULAR_DOTNET.Data.Models;
using WEBAPP_ANGULAR_DOTNET.Data.Services;

namespace WEBAPP_ANGULAR_DOTNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController(IPublisherService publisherService, ILogger<PublisherController> logger) : ControllerBase
    {
        private readonly IPublisherService _publisherService = publisherService;
        private readonly ILogger<PublisherController> _logger = logger;

        // Create or Add a new Publisher
        [HttpPost("AddPublisher")]
        public async Task<IActionResult> AddPublisher([FromBody] Publisher publisher)
        {
            try
            {
                await _publisherService.AddPublisher(publisher);
                var response = new { message = "Publisher added successfully" };
                _logger.LogInformation("Adding publisher: {publisher}", response);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error adding publisher: {error}", ex.Message);
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // Update an existing Publisher
        [HttpPut("UpdatePublisher/{id}")]
        public async Task<IActionResult> UpdatePublisher(int id, [FromBody] Publisher publisher)
        {
            try
            {
                await _publisherService.UpdatePublisher(id, publisher);
                var response = new { message = $"Update {publisher.Name} successfully" };
                _logger.LogInformation("Updating publisher: {publisher}", response);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error updating publisher: {error}", ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        // Delete an existing Publisher
        [HttpDelete("DeletePublisher/{id}")]
        public async Task<IActionResult> DeletePublisher(int id)
        {
            try
            {
                await _publisherService.DeletePublisher(id);
                var response = new { message = $"Publisher with ID {id} deleted successfully" };
                _logger.LogInformation("Deleting publisher: {response}", response);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error deleting publisher: {error}", ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        // Get a single Publisher by ID
        [HttpGet("GetSinglePublisher/{id}")]
        public async Task<IActionResult> GetPublisherById(int id)
        {
            try
            {
                var publisher = await _publisherService.GetPublisherById(id);
                _logger.LogInformation("Getting publisher by ID: {publisher}", publisher);
                return Ok(publisher);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error getting publisher by ID: {error}", ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        // Get all Publishers
        [HttpGet("GetAllPublishers")]
        public async Task<IActionResult> GetAllPublishers()
        {
            try
            {
                var publishers = await _publisherService.GetAllPublishers();
                _logger.LogInformation("Getting all publishers: {publishers}", publishers);
                return Ok(publishers);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error getting all publishers: {error}", ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}