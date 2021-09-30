using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Migration_022 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_goods_goods",
                table: "Order_Goods");

            migrationBuilder.DropForeignKey(
                name: "FK_order_goods_order",
                table: "Order_Goods");

            migrationBuilder.AddForeignKey(
                name: "FK_order_goods_goods",
                table: "Order_Goods",
                column: "GoodsId",
                principalTable: "Goods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_goods_order",
                table: "Order_Goods",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_goods_goods",
                table: "Order_Goods");

            migrationBuilder.DropForeignKey(
                name: "FK_order_goods_order",
                table: "Order_Goods");

            migrationBuilder.AddForeignKey(
                name: "FK_order_goods_goods",
                table: "Order_Goods",
                column: "GoodsId",
                principalTable: "Goods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_order_goods_order",
                table: "Order_Goods",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
