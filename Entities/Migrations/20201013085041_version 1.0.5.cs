using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class version105 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Districts_DistrictId",
                table: "Addresses");

            migrationBuilder.AlterColumn<int>(
                name: "DistrictId",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Districts_DistrictId",
                table: "Addresses",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Districts_DistrictId",
                table: "Addresses");

            migrationBuilder.AlterColumn<int>(
                name: "DistrictId",
                table: "Addresses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Districts_DistrictId",
                table: "Addresses",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
