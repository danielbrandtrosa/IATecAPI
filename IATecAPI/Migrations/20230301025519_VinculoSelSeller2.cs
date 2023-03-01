using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IATecAPI.Migrations
{
    public partial class VinculoSelSeller2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sels_Sellers_SellerId",
                table: "Sels");

            migrationBuilder.AlterColumn<int>(
                name: "SellerId",
                table: "Sels",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Sels_Sellers_SellerId",
                table: "Sels",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sels_Sellers_SellerId",
                table: "Sels");

            migrationBuilder.AlterColumn<int>(
                name: "SellerId",
                table: "Sels",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sels_Sellers_SellerId",
                table: "Sels",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
