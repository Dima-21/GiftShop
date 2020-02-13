using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Migration_006 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Charact_Group_GroupId",
                table: "Charact");

            migrationBuilder.DropIndex(
                name: "IX_Charact_GroupId",
                table: "Charact");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Charact");

            migrationBuilder.CreateIndex(
                name: "IX_Goods_GroupId",
                table: "Goods",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Goods_Group",
                table: "Goods",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goods_Group",
                table: "Goods");

            migrationBuilder.DropIndex(
                name: "IX_Goods_GroupId",
                table: "Goods");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Charact",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Charact_GroupId",
                table: "Charact",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Charact_Group_GroupId",
                table: "Charact",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
