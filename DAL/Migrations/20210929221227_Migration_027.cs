using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Migration_027 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_charact_property",
                table: "Charact");

            migrationBuilder.DropForeignKey(
                name: "FK_Property_Group_GroupId",
                table: "Property");

            migrationBuilder.AddForeignKey(
                name: "FK_charact_property",
                table: "Charact",
                column: "PropId",
                principalTable: "Property",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Property_Group",
                table: "Property",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_charact_property",
                table: "Charact");

            migrationBuilder.DropForeignKey(
                name: "FK_Property_Group",
                table: "Property");

            migrationBuilder.AddForeignKey(
                name: "FK_charact_property",
                table: "Charact",
                column: "PropId",
                principalTable: "Property",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Property_Group_GroupId",
                table: "Property",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
