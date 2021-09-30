using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Migration_025 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StatusName",
                table: "OrderStatus",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<short>(
                name: "StatusCode",
                table: "OrderStatus",
                nullable: false,
                defaultValue: (short)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusCode",
                table: "OrderStatus");

            migrationBuilder.AlterColumn<string>(
                name: "StatusName",
                table: "OrderStatus",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
