using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Migration_008 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_goods_price",
                table: "Goods");

            migrationBuilder.DropTable(
                name: "Price");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Goods",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Goods",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Price", "PriceId" },
                values: new object[] { 150m, 0 });

            migrationBuilder.UpdateData(
                table: "Goods",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Price", "PriceId" },
                values: new object[] { 300m, 0 });

            migrationBuilder.UpdateData(
                table: "Goods",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Price", "PriceId" },
                values: new object[] { 450m, 0 });

            migrationBuilder.UpdateData(
                table: "Goods",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Price", "PriceId" },
                values: new object[] { 120m, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Goods");

            migrationBuilder.CreateTable(
                name: "Price",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrigPrice = table.Column<decimal>(type: "money", nullable: false),
                    PercentDisc = table.Column<byte>(nullable: false),
                    SpecPrice = table.Column<decimal>(type: "money", nullable: false),
                    SumDisc = table.Column<decimal>(type: "money", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Price", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Price",
                columns: new[] { "Id", "OrigPrice", "PercentDisc", "SpecPrice", "SumDisc", "ValidFrom" },
                values: new object[,]
                {
                    { 1, 550m, (byte)0, 0m, 0m, new DateTime(2020, 2, 12, 23, 31, 38, 132, DateTimeKind.Local) },
                    { 2, 340m, (byte)20, 0m, 0m, new DateTime(2020, 2, 12, 23, 31, 38, 134, DateTimeKind.Local) },
                    { 3, 450m, (byte)0, 0m, 100m, new DateTime(2020, 2, 12, 23, 31, 38, 135, DateTimeKind.Local) },
                    { 4, 220m, (byte)0, 0m, 0m, new DateTime(2020, 2, 12, 23, 31, 38, 135, DateTimeKind.Local) }
                });

            migrationBuilder.UpdateData(
                table: "Goods",
                keyColumn: "Id",
                keyValue: 1,
                column: "PriceId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Goods",
                keyColumn: "Id",
                keyValue: 2,
                column: "PriceId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Goods",
                keyColumn: "Id",
                keyValue: 3,
                column: "PriceId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Goods",
                keyColumn: "Id",
                keyValue: 4,
                column: "PriceId",
                value: 4);

            migrationBuilder.CreateIndex(
                name: "UK_price",
                table: "Price",
                column: "Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_goods_price",
                table: "Goods",
                column: "PriceId",
                principalTable: "Price",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
