using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Migration_013 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_charact_goods",
                table: "Charact");

            migrationBuilder.DropForeignKey(
                name: "FK_goods_image_goods",
                table: "Goods_Image");

            migrationBuilder.DropForeignKey(
                name: "FK_order_goods_goods",
                table: "Order_Goods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Goods",
                table: "Goods");

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
                table: "Goods",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Goods");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Goods",
                newName: "GoodsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Goods",
                table: "Goods",
                column: "GoodsId");

            migrationBuilder.AddForeignKey(
                name: "FK_charact_goods",
                table: "Charact",
                column: "GoodsId",
                principalTable: "Goods",
                principalColumn: "GoodsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_goods_image_goods",
                table: "Goods_Image",
                column: "GoodsId",
                principalTable: "Goods",
                principalColumn: "GoodsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_goods_goods",
                table: "Order_Goods",
                column: "GoodsId",
                principalTable: "Goods",
                principalColumn: "GoodsId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_charact_goods",
                table: "Charact");

            migrationBuilder.DropForeignKey(
                name: "FK_goods_image_goods",
                table: "Goods_Image");

            migrationBuilder.DropForeignKey(
                name: "FK_order_goods_goods",
                table: "Order_Goods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Goods",
                table: "Goods");

            migrationBuilder.RenameColumn(
                name: "GoodsId",
                table: "Goods",
                newName: "Code");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Goods",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Goods",
                table: "Goods",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Goods",
                columns: new[] { "Id", "Amount", "Code", "Descript", "GroupId", "IsHidden", "Name", "Price", "PublishData", "ShortDescript" },
                values: new object[,]
                {
                    { 1, (short)10, 100000, "Подарочный набор 1. Полное описание", 1, false, "Подарочный набор 1", 150m, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Подарочный набор 1. Описание" },
                    { 2, (short)0, 100001, "Подарочный набор 2. Полное описание", 1, false, "Подарочный набор 2", 300m, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Подарочный набор 2. Описание" },
                    { 3, (short)2, 100002, "Подарочный набор 3. Полное описание", 1, false, "Подарочный набор 3", 450m, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Подарочный набор 3. Описание" },
                    { 4, (short)15, 200000, "Конфеты Raffaello. Полное описание", 2, false, "Конфеты Raffaello", 120m, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Конфеты Raffaello 240г" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_charact_goods",
                table: "Charact",
                column: "GoodsId",
                principalTable: "Goods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_goods_image_goods",
                table: "Goods_Image",
                column: "GoodsId",
                principalTable: "Goods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_goods_goods",
                table: "Order_Goods",
                column: "GoodsId",
                principalTable: "Goods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
