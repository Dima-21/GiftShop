using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Migration_004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FExt",
                table: "Image");

            migrationBuilder.InsertData(
                table: "Price",
                columns: new[] { "Id", "OrigPrice", "PercentDisc", "SpecPrice", "SumDisc", "ValidFrom" },
                values: new object[,]
                {
                    { 1, 550m, (byte)0, 0m, 0m, new DateTime(2020, 2, 10, 23, 34, 18, 470, DateTimeKind.Local) },
                    { 2, 340m, (byte)20, 0m, 0m, new DateTime(2020, 2, 10, 23, 34, 18, 473, DateTimeKind.Local) },
                    { 3, 450m, (byte)0, 0m, 100m, new DateTime(2020, 2, 10, 23, 34, 18, 473, DateTimeKind.Local) },
                    { 4, 220m, (byte)0, 0m, 0m, new DateTime(2020, 2, 10, 23, 34, 18, 473, DateTimeKind.Local) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Price",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Price",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Price",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Price",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AddColumn<string>(
                name: "FExt",
                table: "Image",
                unicode: false,
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }
    }
}
