using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarCatalog.Data.Migrations
{
    public partial class ChangedTheCarInfoClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarInfos_Cars_CarId",
                table: "CarInfos");

            migrationBuilder.DropIndex(
                name: "IX_CarInfos_CarId",
                table: "CarInfos");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "CarInfos");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarInfoId",
                table: "Cars",
                column: "CarInfoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarInfos_CarInfoId",
                table: "Cars",
                column: "CarInfoId",
                principalTable: "CarInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarInfos_CarInfoId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CarInfoId",
                table: "Cars");

            migrationBuilder.AddColumn<Guid>(
                name: "CarId",
                table: "CarInfos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CarInfos_CarId",
                table: "CarInfos",
                column: "CarId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CarInfos_Cars_CarId",
                table: "CarInfos",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
