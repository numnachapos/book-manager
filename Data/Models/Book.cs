using System.ComponentModel.DataAnnotations;
using WEBAPP_ANGULAR_DOTNET.Data.Models.Enum;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBAPP_ANGULAR_DOTNET.Data.Models
{
    public abstract class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public abstract BookTypes BookType { get; set; }

        [Required]
        [MaxLength(255)]
        public required string Title { get; set; }

        [Required]
        [MaxLength(255)]
        public required string Author { get; set; }

        [Required]
        [MaxLength(500)]
        public required string Description { get; set; }

        public double? Rate { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateRead { get; set; }
        public DateTime? DateEnd { get; set; }

        //Foreign Key
        [ForeignKey("Publisher")]
        public int PublisherId { get; set; }

        // Navigation property
        public required Publisher Publisher { get; set; }

        // Parameterless constructor
        protected Book() { }

        [JsonConstructor]
        public Book(int id, string title, string author, string description, double? rate, DateTime? dateStart, DateTime? dateRead, DateTime? dateEnd, int publisherId, Publisher publisher)
        {
            Id = id;
            Title = title;
            Author = author;
            Description = description;
            Rate = rate;
            DateStart = dateStart;
            DateRead = dateRead;
            DateEnd = dateEnd;
            PublisherId = publisherId;
        }
    }
}