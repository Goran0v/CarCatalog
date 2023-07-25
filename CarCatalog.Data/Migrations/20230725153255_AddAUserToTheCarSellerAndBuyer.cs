using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarCatalog.Data.Migrations
{
    public partial class AddAUserToTheCarSellerAndBuyer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "CarSellers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationUserId",
                table: "Cars",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "CarBuyers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CarSellers_UserId",
                table: "CarSellers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ApplicationUserId",
                table: "Cars",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CarBuyers_UserId",
                table: "CarBuyers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarBuyers_AspNetUsers_UserId",
                table: "CarBuyers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_AspNetUsers_ApplicationUserId",
                table: "Cars",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarSellers_AspNetUsers_UserId",
                table: "CarSellers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarBuyers_AspNetUsers_UserId",
                table: "CarBuyers");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_AspNetUsers_ApplicationUserId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_CarSellers_AspNetUsers_UserId",
                table: "CarSellers");

            migrationBuilder.DropIndex(
                name: "IX_CarSellers_UserId",
                table: "CarSellers");

            migrationBuilder.DropIndex(
                name: "IX_Cars_ApplicationUserId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_CarBuyers_UserId",
                table: "CarBuyers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CarSellers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CarBuyers");
        }
    }
}
