using System.ComponentModel.DataAnnotations;
namespace WEBAPP_ANGULAR_DOTNET.Data.Models.Categories
{
    public class CryptoCurrencyBook : Book
    {
        [Required]
        public required string CurrencyType { get; set; }
        
        [Required]
        public required string MarketTrend { get; set; }
    }
}
