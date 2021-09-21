using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Migration_014 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GoodsId",
                table: "Goods",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "Code",
                table: "Goods",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Goods");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Goods",
                newName: "GoodsId");
        }
    }
}
