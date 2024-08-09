using System.ComponentModel.DataAnnotations;

namespace WEBAPP_ANGULAR_DOTNET.Data.Models.Categories
{
    public class BiographyBook : Book
    {
        [Required]
        public required string Subject { get; set; }

        [Required]
        public required string TimePeriod { get; set; }
    }
}