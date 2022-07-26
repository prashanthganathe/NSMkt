﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NSMkt.Data.Migrations
{
    public partial class stock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CECount",
                schema: "Identity",
                table: "OptionChainSummary");

            migrationBuilder.DropColumn(
                name: "IsDoji",
                schema: "Identity",
                table: "OptionChainSummary");

            migrationBuilder.DropColumn(
                name: "PECount",
                schema: "Identity",
                table: "OptionChainSummary");

            migrationBuilder.DropColumn(
                name: "prev1Resistance",
                schema: "Identity",
                table: "OptionChainSummary");

            migrationBuilder.DropColumn(
                name: "prev1Resistance1",
                schema: "Identity",
                table: "OptionChainSummary");

            migrationBuilder.DropColumn(
                name: "prev1Support",
                schema: "Identity",
                table: "OptionChainSummary");

            migrationBuilder.DropColumn(
                name: "prev1Support1",
                schema: "Identity",
                table: "OptionChainSummary");

            migrationBuilder.DropColumn(
                name: "prev2Resistance",
                schema: "Identity",
                table: "OptionChainSummary");

            migrationBuilder.DropColumn(
                name: "prev2Resistance1",
                schema: "Identity",
                table: "OptionChainSummary");

            migrationBuilder.DropColumn(
                name: "prev2Support",
                schema: "Identity",
                table: "OptionChainSummary");

            migrationBuilder.DropColumn(
                name: "prev2Support1",
                schema: "Identity",
                table: "OptionChainSummary");

            migrationBuilder.CreateTable(
                name: "OptionChainStockSummary",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    group = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    analysisTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    script = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    expiry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    expiryType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    openPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    highPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    lowPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    isSpot = table.Column<bool>(type: "bit", nullable: false),
                    strike_reflabel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    futureprice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    indexprice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ceoi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    cecoi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    cevolume = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ceiv = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    celtp = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    celtpchange = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    strike = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    peltpchange = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    peltp = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    peiv = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    pevolume = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    pecoi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    peoi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Res1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Sup1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Res2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Sup2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    isResVolStrong = table.Column<bool>(type: "bit", nullable: false),
                    isResOIStrong = table.Column<bool>(type: "bit", nullable: false),
                    isSupVolStrong = table.Column<bool>(type: "bit", nullable: false),
                    isSupOIStrong = table.Column<bool>(type: "bit", nullable: false),
                    PECOIDiffPer = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CECOIDiffPer = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CECount = table.Column<int>(type: "int", nullable: false),
                    PECount = table.Column<int>(type: "int", nullable: false),
                    IsDoji = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    prev1 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    prev1Support = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    prev1Resistance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    prev1Support1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    prev1Resistance1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    prev2 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    prev2Support = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    prev2Resistance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    prev2Support1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    prev2Resistance1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SummaryJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionChainStockSummary", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OptionChainStockSummary",
                schema: "Identity");

            migrationBuilder.AddColumn<int>(
                name: "CECount",
                schema: "Identity",
                table: "OptionChainSummary",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "IsDoji",
                schema: "Identity",
                table: "OptionChainSummary",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "PECount",
                schema: "Identity",
                table: "OptionChainSummary",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "prev1Resistance",
                schema: "Identity",
                table: "OptionChainSummary",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "prev1Resistance1",
                schema: "Identity",
                table: "OptionChainSummary",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "prev1Support",
                schema: "Identity",
                table: "OptionChainSummary",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "prev1Support1",
                schema: "Identity",
                table: "OptionChainSummary",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "prev2Resistance",
                schema: "Identity",
                table: "OptionChainSummary",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "prev2Resistance1",
                schema: "Identity",
                table: "OptionChainSummary",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "prev2Support",
                schema: "Identity",
                table: "OptionChainSummary",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "prev2Support1",
                schema: "Identity",
                table: "OptionChainSummary",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
