using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class SZ_Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SmartZones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SmartZoneName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SmartZoneAddress1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SmartZoneAddress2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsExpired = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmartZones", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SmartZones");
        }
    }
}
