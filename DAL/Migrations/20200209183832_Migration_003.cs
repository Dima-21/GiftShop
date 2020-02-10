using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Migration_003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageName",
                table: "Group",
                newName: "Image");

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Group",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "Id", "DataEnd", "DataStart", "Icon", "Image", "Name", "ShortDescript" },
                values: new object[] { 1, null, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), "group-icon-gift.png", null, "Подарочные наборы", null });

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "Id", "DataEnd", "DataStart", "Icon", "Image", "Name", "ShortDescript" },
                values: new object[] { 2, null, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), "group-icon-sweets.png", null, "Сладости", null });

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "Id", "DataEnd", "DataStart", "Icon", "Image", "Name", "ShortDescript" },
                values: new object[] { 3, null, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), "group-icon-allToParty.png", null, "Всё для праздника", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Group");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Group",
                newName: "ImageName");
        }
    }
}
