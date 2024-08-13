using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WEBAPP_ANGULAR_DOTNET.Data.Models
{
    public class Publisher
    {
        [Key]
        public int PublisherId { get; set; }

        [Required]
        [MaxLength(255)]
        public required string Name { get; set; }

        public ICollection<Book> Books { get; set; } = [];
    }
}