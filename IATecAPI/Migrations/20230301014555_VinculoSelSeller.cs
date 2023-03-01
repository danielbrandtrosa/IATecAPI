using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IATecAPI.Migrations
{
    public partial class VinculoSelSeller : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SellerId",
                table: "Sels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sels_SellerId",
                table: "Sels",
                column: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sels_Sellers_SellerId",
                table: "Sels",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sels_Sellers_SellerId",
                table: "Sels");

            migrationBuilder.DropIndex(
                name: "IX_Sels_SellerId",
                table: "Sels");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "Sels");
        }
    }
}
