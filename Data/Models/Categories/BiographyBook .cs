using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WEBAPP_ANGULAR_DOTNET.Data.Models.Enum;

namespace WEBAPP_ANGULAR_DOTNET.Data.Models.Categories
{
    public class BiographyBook : Book
    {
        public override BookTypes BookType { get; set; } = BookTypes.BiographyBook;

        [Required]
        public required string Subject { get; set; }

        [Required]
        public required string TimePeriod { get; set; }

        // Parameterless constructor
        public BiographyBook() { }

        [JsonConstructor]
        public BiographyBook(int id, string title, string author, string description, double? rate, DateTime? dateStart, DateTime? dateRead, DateTime? dateEnd, int publisherId, Publisher publisher, string subject, string timePeriod)
            : base(id, title, author, description, rate, dateStart, dateRead, dateEnd, publisherId, publisher)
        {
            Subject = subject;
            TimePeriod = timePeriod;
        }
    }
}