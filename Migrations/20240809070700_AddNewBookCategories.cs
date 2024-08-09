using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBAPP_ANGULAR_DOTNET.Migrations
{
    /// <inheritdoc />
    public partial class AddNewBookCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookType",
                table: "Books",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CurrencyType",
                table: "Books",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Books",
                type: "character varying(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InvestmentType",
                table: "Books",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MarketTrend",
                table: "Books",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Strategy",
                table: "Books",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Books",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimePeriod",
                table: "Books",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookType",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CurrencyType",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "InvestmentType",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "MarketTrend",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Strategy",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "TimePeriod",
                table: "Books");
        }
    }
}
