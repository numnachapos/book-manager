using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WEBAPP_ANGULAR_DOTNET.Data.Models.Enum;

namespace WEBAPP_ANGULAR_DOTNET.Data.Models.Categories
{
    public class CryptoCurrencyBook : Book
    {
        public override BookTypes BookType { get; set; } = BookTypes.CryptoCurrencyBook;

        [Required]
        public required string CurrencyType { get; set; }
        
        [Required]
        public required string MarketTrend { get; set; }

        // Parameterless constructor
        public CryptoCurrencyBook() : base() { }

        // Constructor with parameters
        [JsonConstructor]
        public CryptoCurrencyBook(int id, string title, string author, string description, double? rate, DateTime? dateStart, DateTime? dateRead, DateTime? dateEnd, int publisherId, Publisher publisher, string currencyType, string marketTrend)
            : base(id, title, author, description, rate, dateStart, dateRead, dateEnd, publisherId, publisher)
        {
            CurrencyType = currencyType;
            MarketTrend = marketTrend;
        }
    }
}