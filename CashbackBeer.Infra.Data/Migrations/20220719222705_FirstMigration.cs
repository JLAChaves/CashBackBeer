using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CashbackBeer.Infra.Data.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    SundayCashback = table.Column<double>(type: "float", nullable: false),
                    MondayCashback = table.Column<double>(type: "float", nullable: false),
                    TuesdayCashback = table.Column<double>(type: "float", nullable: false),
                    WednesdayCashback = table.Column<double>(type: "float", nullable: false),
                    ThursdayCashback = table.Column<double>(type: "float", nullable: false),
                    FridayCashback = table.Column<double>(type: "float", nullable: false),
                    SaturdayCashback = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinalSales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalSaleValue = table.Column<double>(type: "float", nullable: true),
                    TotalCashback = table.Column<double>(type: "float", nullable: true),
                    TotalCashbackValue = table.Column<double>(type: "float", nullable: true),
                    DateSale = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinalSales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartialSales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ValuePartialSale = table.Column<double>(type: "float", nullable: true),
                    CashbackPercentage = table.Column<double>(type: "float", nullable: true),
                    CashbackValue = table.Column<double>(type: "float", nullable: true),
                    DateSale = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinalSaleId = table.Column<int>(type: "int", nullable: false),
                    BeerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartialSales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartialSales_Beers_BeerId",
                        column: x => x.BeerId,
                        principalTable: "Beers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartialSales_FinalSales_FinalSaleId",
                        column: x => x.FinalSaleId,
                        principalTable: "FinalSales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Beers",
                columns: new[] { "Id", "FridayCashback", "MondayCashback", "Name", "SaturdayCashback", "SundayCashback", "ThursdayCashback", "TuesdayCashback", "Value", "WednesdayCashback" },
                values: new object[,]
                {
                    { 1, 0.14999999999999999, 0.070000000000000007, "SKOL", 0.20000000000000001, 0.25, 0.10000000000000001, 0.059999999999999998, 3.0, 0.02 },
                    { 2, 0.25, 0.050000000000000003, "BRAHMA", 0.29999999999999999, 0.29999999999999999, 0.20000000000000001, 0.10000000000000001, 4.0, 0.14999999999999999 },
                    { 3, 0.17999999999999999, 0.029999999999999999, "STELLA", 0.25, 0.34999999999999998, 0.13, 0.050000000000000003, 5.0, 0.080000000000000002 },
                    { 4, 0.20000000000000001, 0.10000000000000001, "BOHEMIA", 0.40000000000000002, 0.40000000000000002, 0.14999999999999999, 0.14999999999999999, 4.0, 0.14999999999999999 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PartialSales_BeerId",
                table: "PartialSales",
                column: "BeerId");

            migrationBuilder.CreateIndex(
                name: "IX_PartialSales_FinalSaleId",
                table: "PartialSales",
                column: "FinalSaleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartialSales");

            migrationBuilder.DropTable(
                name: "Beers");

            migrationBuilder.DropTable(
                name: "FinalSales");
        }
    }
}
