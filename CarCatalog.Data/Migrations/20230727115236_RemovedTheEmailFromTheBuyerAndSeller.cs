using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarCatalog.Data.Migrations
{
    public partial class RemovedTheEmailFromTheBuyerAndSeller : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "CarSellers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "CarBuyers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "CarSellers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "CarBuyers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }
    }
}
