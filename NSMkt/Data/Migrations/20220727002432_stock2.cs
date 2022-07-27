using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NSMkt.Data.Migrations
{
    public partial class stock2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "openPrice",
                schema: "Identity",
                table: "OptionChainStockSummary",
                newName: "yearLow");

            migrationBuilder.RenameColumn(
                name: "lowPrice",
                schema: "Identity",
                table: "OptionChainStockSummary",
                newName: "yearHigh");

            migrationBuilder.RenameColumn(
                name: "highPrice",
                schema: "Identity",
                table: "OptionChainStockSummary",
                newName: "prevClose");

            migrationBuilder.AddColumn<decimal>(
                name: "High",
                schema: "Identity",
                table: "OptionChainStockSummary",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsTop50",
                schema: "Identity",
                table: "OptionChainStockSummary",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Low",
                schema: "Identity",
                table: "OptionChainStockSummary",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Open",
                schema: "Identity",
                table: "OptionChainStockSummary",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TurnOver",
                schema: "Identity",
                table: "OptionChainStockSummary",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ltp",
                schema: "Identity",
                table: "OptionChainStockSummary",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "High",
                schema: "Identity",
                table: "OptionChainStockSummary");

            migrationBuilder.DropColumn(
                name: "IsTop50",
                schema: "Identity",
                table: "OptionChainStockSummary");

            migrationBuilder.DropColumn(
                name: "Low",
                schema: "Identity",
                table: "OptionChainStockSummary");

            migrationBuilder.DropColumn(
                name: "Open",
                schema: "Identity",
                table: "OptionChainStockSummary");

            migrationBuilder.DropColumn(
                name: "TurnOver",
                schema: "Identity",
                table: "OptionChainStockSummary");

            migrationBuilder.DropColumn(
                name: "ltp",
                schema: "Identity",
                table: "OptionChainStockSummary");

            migrationBuilder.RenameColumn(
                name: "yearLow",
                schema: "Identity",
                table: "OptionChainStockSummary",
                newName: "openPrice");

            migrationBuilder.RenameColumn(
                name: "yearHigh",
                schema: "Identity",
                table: "OptionChainStockSummary",
                newName: "lowPrice");

            migrationBuilder.RenameColumn(
                name: "prevClose",
                schema: "Identity",
                table: "OptionChainStockSummary",
                newName: "highPrice");
        }
    }
}
