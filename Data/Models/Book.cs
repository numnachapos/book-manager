using System.ComponentModel.DataAnnotations;
using WEBAPP_ANGULAR_DOTNET.Data.Models.Enum;

namespace WEBAPP_ANGULAR_DOTNET.Data.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public BookTypes BookType { get; set; }

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
    }
}