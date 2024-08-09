using System.ComponentModel.DataAnnotations;

namespace WEBAPP_ANGULAR_DOTNET.Data.Models.Categories
{
    public class BiographyBook : Book
    {
        public required string Subject { get; set; }
        public required string TimePeriod { get; set; }
    }
}