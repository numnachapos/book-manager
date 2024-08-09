using System.ComponentModel.DataAnnotations;
namespace WEBAPP_ANGULAR_DOTNET.Data.Models.Categories
{
    public class CryptoCurrencyBook : Book
    {
        public required string CurrencyType { get; set; }
        public required string MarketTrend { get; set; }
    }
}
