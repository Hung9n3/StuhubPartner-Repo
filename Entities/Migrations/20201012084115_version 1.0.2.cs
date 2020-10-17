using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class version102 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Cities_CityID",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Districts_DistrictID",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Addresses_AddressID",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Locations_LocationID",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Menus_MenuID",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationImage_Locations_LocationID",
                table: "LocationImage");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Addresses_AddressID",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Menus_MenuID",
                table: "Locations");

            migrationBuilder.RenameColumn(
                name: "MenuID",
                table: "Menus",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MenuID",
                table: "Locations",
                newName: "MenuId");

            migrationBuilder.RenameColumn(
                name: "AddressID",
                table: "Locations",
                newName: "AddressId");

            migrationBuilder.RenameColumn(
                name: "LocationID",
                table: "Locations",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_MenuID",
                table: "Locations",
                newName: "IX_Locations_MenuId");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_AddressID",
                table: "Locations",
                newName: "IX_Locations_AddressId");

            migrationBuilder.RenameColumn(
                name: "LocationID",
                table: "LocationImage",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_LocationImage_LocationID",
                table: "LocationImage",
                newName: "IX_LocationImage_LocationId");

            migrationBuilder.RenameColumn(
                name: "MenuID",
                table: "Items",
                newName: "MenuId");

            migrationBuilder.RenameColumn(
                name: "ItemID",
                table: "Items",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Items_MenuID",
                table: "Items",
                newName: "IX_Items_MenuId");

            migrationBuilder.RenameColumn(
                name: "LocationID",
                table: "Employees",
                newName: "LocationId");

            migrationBuilder.RenameColumn(
                name: "AddressID",
                table: "Employees",
                newName: "AddressId");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Employees",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_LocationID",
                table: "Employees",
                newName: "IX_Employees_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_AddressID",
                table: "Employees",
                newName: "IX_Employees_AddressId");

            migrationBuilder.RenameColumn(
                name: "DistrictID",
                table: "Districts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CityID",
                table: "Cities",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DistrictID",
                table: "Addresses",
                newName: "DistrictId");

            migrationBuilder.RenameColumn(
                name: "CityID",
                table: "Addresses",
                newName: "CityId");

            migrationBuilder.RenameColumn(
                name: "AddressID",
                table: "Addresses",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_DistrictID",
                table: "Addresses",
                newName: "IX_Addresses_DistrictId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_CityID",
                table: "Addresses",
                newName: "IX_Addresses_CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Cities_CityId",
                table: "Addresses",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Districts_DistrictId",
                table: "Addresses",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Addresses_AddressId",
                table: "Employees",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Locations_LocationId",
                table: "Employees",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Menus_MenuId",
                table: "Items",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationImage_Locations_LocationId",
                table: "LocationImage",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Addresses_AddressId",
                table: "Locations",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Menus_MenuId",
                table: "Locations",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Cities_CityId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Districts_DistrictId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Addresses_AddressId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Locations_LocationId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Menus_MenuId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationImage_Locations_LocationId",
                table: "LocationImage");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Addresses_AddressId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Menus_MenuId",
                table: "Locations");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Menus",
                newName: "MenuID");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "Locations",
                newName: "MenuID");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Locations",
                newName: "AddressID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Locations",
                newName: "LocationID");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_MenuId",
                table: "Locations",
                newName: "IX_Locations_MenuID");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_AddressId",
                table: "Locations",
                newName: "IX_Locations_AddressID");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "LocationImage",
                newName: "LocationID");

            migrationBuilder.RenameIndex(
                name: "IX_LocationImage_LocationId",
                table: "LocationImage",
                newName: "IX_LocationImage_LocationID");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "Items",
                newName: "MenuID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Items",
                newName: "ItemID");

            migrationBuilder.RenameIndex(
                name: "IX_Items_MenuId",
                table: "Items",
                newName: "IX_Items_MenuID");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Employees",
                newName: "LocationID");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Employees",
                newName: "AddressID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Employees",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_LocationId",
                table: "Employees",
                newName: "IX_Employees_LocationID");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_AddressId",
                table: "Employees",
                newName: "IX_Employees_AddressID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Districts",
                newName: "DistrictID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cities",
                newName: "CityID");

            migrationBuilder.RenameColumn(
                name: "DistrictId",
                table: "Addresses",
                newName: "DistrictID");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Addresses",
                newName: "CityID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Addresses",
                newName: "AddressID");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_DistrictId",
                table: "Addresses",
                newName: "IX_Addresses_DistrictID");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                newName: "IX_Addresses_CityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Cities_CityID",
                table: "Addresses",
                column: "CityID",
                principalTable: "Cities",
                principalColumn: "CityID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Districts_DistrictID",
                table: "Addresses",
                column: "DistrictID",
                principalTable: "Districts",
                principalColumn: "DistrictID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Addresses_AddressID",
                table: "Employees",
                column: "AddressID",
                principalTable: "Addresses",
                principalColumn: "AddressID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Locations_LocationID",
                table: "Employees",
                column: "LocationID",
                principalTable: "Locations",
                principalColumn: "LocationID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Menus_MenuID",
                table: "Items",
                column: "MenuID",
                principalTable: "Menus",
                principalColumn: "MenuID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationImage_Locations_LocationID",
                table: "LocationImage",
                column: "LocationID",
                principalTable: "Locations",
                principalColumn: "LocationID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Addresses_AddressID",
                table: "Locations",
                column: "AddressID",
                principalTable: "Addresses",
                principalColumn: "AddressID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Menus_MenuID",
                table: "Locations",
                column: "MenuID",
                principalTable: "Menus",
                principalColumn: "MenuID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
