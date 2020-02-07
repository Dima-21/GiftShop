using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class migration_001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Goods_Hprop");

            migrationBuilder.DropTable(
                name: "Hproduct");

            migrationBuilder.AddColumn<short>(
                name: "Amount",
                table: "Goods",
                nullable: false,
                defaultValue: (short)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Goods");

            migrationBuilder.CreateTable(
                name: "Hproduct",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataEnd = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataStart = table.Column<DateTime>(type: "datetime", nullable: false),
                    Height = table.Column<double>(nullable: true),
                    ImageId = table.Column<int>(nullable: true),
                    Length = table.Column<double>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    ValInBox = table.Column<int>(nullable: true),
                    Weight = table.Column<int>(nullable: true),
                    Width = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hproduct", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Goods_Hprop",
                columns: table => new
                {
                    GoodsId = table.Column<int>(nullable: false),
                    ProdId = table.Column<int>(nullable: false),
                    Amount = table.Column<short>(nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goods_Hprop", x => new { x.GoodsId, x.ProdId });
                    table.ForeignKey(
                        name: "FK_goods_hprop_goods",
                        column: x => x.GoodsId,
                        principalTable: "Goods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_goods_hprop_hproduct",
                        column: x => x.ProdId,
                        principalTable: "Hproduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Goods_Hprop_ProdId",
                table: "Goods_Hprop",
                column: "ProdId");

            migrationBuilder.CreateIndex(
                name: "UK_goods_hprop",
                table: "Goods_Hprop",
                columns: new[] { "GoodsId", "ProdId" },
                unique: true);
        }
    }
}
