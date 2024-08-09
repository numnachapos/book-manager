using Microsoft.AspNetCore.Mvc;
using WEBAPP_ANGULAR_DOTNET.Data.Models.Enum;
using System.Linq;

namespace WEBAPP_ANGULAR_DOTNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookTypesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBookTypes()
        {
            try
            {
                var bookTypes = Enum.GetValues(typeof(BookTypes))
                                    .Cast<BookTypes>()
                                    .Select(bt => new { Id = (int)bt, Name = bt.ToString() })
                                    .ToList();
                return Ok(bookTypes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}