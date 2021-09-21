using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Migration_012 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Property",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Property_GroupId",
                table: "Property",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Property_Group_GroupId",
                table: "Property",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Property_Group_GroupId",
                table: "Property");

            migrationBuilder.DropIndex(
                name: "IX_Property_GroupId",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Property");
        }
    }
}
