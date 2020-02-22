using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Migration_011 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_goods_image_goods",
                table: "Goods_Image");

            migrationBuilder.DropForeignKey(
                name: "FK_goods_image",
                table: "Goods_Image");

            migrationBuilder.AddForeignKey(
                name: "FK_goods_image_goods",
                table: "Goods_Image",
                column: "GoodsId",
                principalTable: "Goods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_goods_image",
                table: "Goods_Image",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_goods_image_goods",
                table: "Goods_Image");

            migrationBuilder.DropForeignKey(
                name: "FK_goods_image",
                table: "Goods_Image");

            migrationBuilder.AddForeignKey(
                name: "FK_goods_image_goods",
                table: "Goods_Image",
                column: "GoodsId",
                principalTable: "Goods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_goods_image",
                table: "Goods_Image",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
