using System.ComponentModel.DataAnnotations;

namespace WEBAPP_ANGULAR_DOTNET.Data.Models.Categories
{
    public class InvestmentBook : Book
    {
        [Required]
        public required string InvestmentType { get; set; }
        
        [Required]
        public required string Strategy { get; set; }
    }
}