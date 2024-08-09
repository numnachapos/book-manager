using System.ComponentModel.DataAnnotations;

namespace WEBAPP_ANGULAR_DOTNET.Data.Models.Categories
{
    public class InvestmentBook : Book
    {
        public required string InvestmentType { get; set; } // Type of investment (e.g., stocks, bonds)
        public required string Strategy { get; set; } // Brief description of the investment strategy
    }
}