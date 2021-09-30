using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Migration_023 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_OrderStatus_OrderStatusId",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderStatus",
                table: "OrderStatus");

            migrationBuilder.RenameTable(
                name: "OrderStatus",
                newName: "OrderStatuses");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Order",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "OrderStatusId",
                table: "Order",
                nullable: false,
                oldClrType: typeof(short),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderStatuses",
                table: "OrderStatuses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_OrderStatuses_OrderStatusId",
                table: "Order",
                column: "OrderStatusId",
                principalTable: "OrderStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_OrderStatuses_OrderStatusId",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderStatuses",
                table: "OrderStatuses");

            migrationBuilder.RenameTable(
                name: "OrderStatuses",
                newName: "OrderStatus");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Order",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<short>(
                name: "OrderStatusId",
                table: "Order",
                nullable: true,
                oldClrType: typeof(short));

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderStatus",
                table: "OrderStatus",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_OrderStatus_OrderStatusId",
                table: "Order",
                column: "OrderStatusId",
                principalTable: "OrderStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
