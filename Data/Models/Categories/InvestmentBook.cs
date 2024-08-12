using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WEBAPP_ANGULAR_DOTNET.Data.Models.Enum;

namespace WEBAPP_ANGULAR_DOTNET.Data.Models.Categories
{
    public class InvestmentBook : Book
    {
        public override BookTypes BookType { get; set; } = BookTypes.InvestmentBook;

        [Required]
        public required string InvestmentType { get; set; }

        [Required]
        public required string Strategy { get; set; }

        // Parameterless constructor
        public InvestmentBook() : base() { }

        // Constructor with parameters
        [JsonConstructor]
        public InvestmentBook(int id, string title, string author, string description, double? rate, DateTime? dateStart, DateTime? dateRead, DateTime? dateEnd, string investmentType, string strategy)
            : base(id, title, author, description, rate, dateStart, dateRead, dateEnd)
        {
            InvestmentType = investmentType;
            Strategy = strategy;
        }
    }
}