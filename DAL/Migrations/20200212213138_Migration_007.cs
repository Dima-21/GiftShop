using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Migration_007 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "Id", "Icon", "Image", "IsHidden", "Name", "ShortDescript" },
                values: new object[,]
                {
                    { 1, "group-icon-gift.png", null, false, "Подарочные наборы", null },
                    { 2, "group-icon-sweets.png", null, false, "Сладости", null },
                    { 3, "group-icon-allToParty.png", null, false, "Всё для праздника", null }
                });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "good1_001.jpg" },
                    { 2, "good1_002.jpg" },
                    { 3, "good1_003.jpg" },
                    { 4, "good2_001.jpg" },
                    { 5, "good2_002.jpg" },
                    { 6, "good2_003.jpg" },
                    { 7, "good3_001.jpg" }
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

            migrationBuilder.InsertData(
                table: "Property",
                columns: new[] { "Id", "IsFilter", "Name" },
                values: new object[,]
                {
                    { 1, false, "Вес" },
                    { 2, true, "Категория людей" }
                });

            migrationBuilder.InsertData(
                table: "Goods",
                columns: new[] { "Id", "Amount", "Code", "Descript", "GroupId", "IsHidden", "Name", "PriceId", "PublishData", "ShortDescript" },
                values: new object[,]
                {
                    { 1, (short)10, 100000, "Подарочный набор 1. Полное описание", 1, false, "Подарочный набор 1", 1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Подарочный набор 1. Описание" },
                    { 2, (short)0, 100001, "Подарочный набор 2. Полное описание", 1, false, "Подарочный набор 2", 2, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Подарочный набор 2. Описание" },
                    { 3, (short)2, 100002, "Подарочный набор 3. Полное описание", 1, false, "Подарочный набор 3", 3, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Подарочный набор 3. Описание" },
                    { 4, (short)15, 200000, "Конфеты Raffaello. Полное описание", 2, false, "Конфеты Raffaello", 4, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Конфеты Raffaello 240г" }
                });

            migrationBuilder.InsertData(
                table: "Charact",
                columns: new[] { "GoodsId", "PropId", "Value" },
                values: new object[,]
                {
                    { 1, 1, "780г" },
                    { 1, 2, "Для детей" },
                    { 2, 1, "560г" },
                    { 2, 2, "Для мужчин" },
                    { 3, 2, "Для девушек" }
                });

            migrationBuilder.InsertData(
                table: "Goods_Image",
                columns: new[] { "GoodsId", "ImageId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 6 },
                    { 3, 7 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Charact",
                keyColumns: new[] { "GoodsId", "PropId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Charact",
                keyColumns: new[] { "GoodsId", "PropId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Charact",
                keyColumns: new[] { "GoodsId", "PropId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Charact",
                keyColumns: new[] { "GoodsId", "PropId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Charact",
                keyColumns: new[] { "GoodsId", "PropId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "Goods",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Goods_Image",
                keyColumns: new[] { "GoodsId", "ImageId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Goods_Image",
                keyColumns: new[] { "GoodsId", "ImageId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Goods_Image",
                keyColumns: new[] { "GoodsId", "ImageId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "Goods_Image",
                keyColumns: new[] { "GoodsId", "ImageId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "Goods_Image",
                keyColumns: new[] { "GoodsId", "ImageId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "Goods_Image",
                keyColumns: new[] { "GoodsId", "ImageId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "Goods_Image",
                keyColumns: new[] { "GoodsId", "ImageId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Goods",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Goods",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Goods",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Price",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Property",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Property",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 1);

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
        }
    }
}
