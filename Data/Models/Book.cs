using System.Text.Json.Serialization;

namespace WEBAPP_ANGULAR_DOTNET.Data.Models
{
    public class Book
    {
        [JsonPropertyName("bookId")]
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required string Description { get; set; }
        public double? Rate { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateRead { get; set; }
        public DateTime? DateEnd { get; set; }
    }
}