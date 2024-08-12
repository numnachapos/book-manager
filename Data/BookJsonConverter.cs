using System.Text.Json;
using System.Text.Json.Serialization;
using WEBAPP_ANGULAR_DOTNET.Data.Models;
using WEBAPP_ANGULAR_DOTNET.Data.Models.Categories;
using WEBAPP_ANGULAR_DOTNET.Data.Models.Enum;

namespace WEBAPP_ANGULAR_DOTNET.Data
{
    public class BookJsonConverter : JsonConverter<Book>
    {
        public override Book Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            JsonElement root = doc.RootElement;

            // Determine the type of Book from the JSON
            BookTypes bookType = (BookTypes)root.GetProperty("bookType").GetInt32();
            Book book = bookType switch
            {
                BookTypes.BiographyBook => JsonSerializer.Deserialize<BiographyBook>(root.GetRawText(), options) ?? throw new InvalidOperationException("Deserialization returned null for BiographyBook."),
                BookTypes.CryptoCurrencyBook => JsonSerializer.Deserialize<CryptoCurrencyBook>(root.GetRawText(), options) ?? throw new InvalidOperationException("Deserialization returned null for CryptoCurrencyBook."),
                BookTypes.InvestmentBook => JsonSerializer.Deserialize<InvestmentBook>(root.GetRawText(), options) ?? throw new InvalidOperationException("Deserialization returned null for InvestmentBook."),
                _ => throw new NotSupportedException($"BookType '{bookType}' is not supported."),
            };
            return book;
        }

        public override void Write(Utf8JsonWriter writer, Book value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, (object)value, value.GetType(), options);
        }
    }
}