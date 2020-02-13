using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Migration_005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_charact_group",
                table: "Charact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Charact",
                table: "Charact");

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

            migrationBuilder.DropColumn(
                name: "DataEnd",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "DataStart",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "DataEnd",
                table: "Goods");

            migrationBuilder.DropColumn(
                name: "DataStart",
                table: "Goods");

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "Group",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishData",
                table: "Goods",
                type: "datetime",
                nullable: false,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "Goods",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Charact",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Charact",
                table: "Charact",
                columns: new[] { "GoodsId", "PropId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Charact_Group_GroupId",
                table: "Charact",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Charact_Group_GroupId",
                table: "Charact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Charact",
                table: "Charact");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "Goods");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataEnd",
                table: "Group",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataStart",
                table: "Group",
                type: "datetime",
                nullable: false,
                defaultValueSql: "(getdate())");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishData",
                table: "Goods",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataEnd",
                table: "Goods",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataStart",
                table: "Goods",
                type: "datetime",
                nullable: false,
                defaultValueSql: "(getdate())");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Charact",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Charact",
                table: "Charact",
                columns: new[] { "GoodsId", "PropId", "GroupId" });

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "Id", "DataEnd", "DataStart", "Icon", "Image", "Name", "ShortDescript" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "group-icon-gift.png", null, "Подарочные наборы", null },
                    { 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "group-icon-sweets.png", null, "Сладости", null },
                    { 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "group-icon-allToParty.png", null, "Всё для праздника", null }
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_charact_group",
                table: "Charact",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
