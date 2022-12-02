using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fudee.Data.Migrations
{
    public partial class nowe_tabele : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Addresses",
                newName: "StreetName");

            migrationBuilder.AddColumn<int>(
                name: "LocalNr",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StreetNr",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocalNr",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "StreetNr",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "StreetName",
                table: "Addresses",
                newName: "Street");
        }
    }
}
