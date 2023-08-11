﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarCatalog.Data.Migrations
{
    public partial class RemovedFiatAndAddedFirstAndLastNameToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarInfos",
                keyColumn: "Id",
                keyValue: new Guid("42ac5131-54a9-4dd0-9d10-6bb8110fd728"));

            migrationBuilder.DeleteData(
                table: "CarInfos",
                keyColumn: "Id",
                keyValue: new Guid("6c0dc587-e1db-4194-8b15-1007f8b3bd1e"));

            migrationBuilder.DeleteData(
                table: "CarInfos",
                keyColumn: "Id",
                keyValue: new Guid("b5ec81b8-d35e-47c8-a812-7b16b4bbe63b"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("5bf7c130-c1c6-4f20-bc46-e3606645b6f0"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("bfd49b07-74a0-4ad6-b7e1-9b97efd3764f"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("bfd7f2c1-e2e3-4ded-8345-1b76fa0a0830"));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "Test");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "Testov");

            migrationBuilder.InsertData(
                table: "CarInfos",
                columns: new[] { "Id", "Brand", "CarType", "Description", "Engine", "EngineDisplacement", "FuelConsumption", "HorsePower", "ImageUrl", "Mileage", "Model", "PriceForSale", "Transmission", "Weight" },
                values: new object[,]
                {
                    { new Guid("4a7369e2-49b0-4a32-aa8c-d11bb88c89e7"), "Audi", "Sedan", "An old but fast classic sedan.", 0, 2.6f, 8.6f, 150, "https://www.auto-data.net/images/f87/Audi-80-V-B4-Typ-8C.jpg", 200000, "80 B4", 16000, 0, 1330 },
                    { new Guid("7f824107-38ac-4dee-a3e9-1039680c1c94"), "Citroen", "Minivan", "A really good family car with low fuel consumption.", 1, 2f, 5.5f, 90, "https://cdn3.focus.bg/autodata/i/citroen/xsara/xsara-picasso-n68/large/93f808a9cfb5a399babc04e50f54eb36.jpg", 150000, "Xsara Picasso", 7000, 0, 1300 }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "ApplicationUserId", "BuyerId", "CarDealerId", "CarInfoId", "SellerId" },
                values: new object[,]
                {
                    { new Guid("a29c60d4-a443-4972-af8a-7ce0e0e21b3f"), null, null, 2, new Guid("223c38c9-9842-452c-867d-31fbb4ab177d"), new Guid("47cecf13-b028-4b4e-990e-6676609b8c8b") },
                    { new Guid("d2037dba-188d-42e2-85f2-f7168111e38d"), null, null, 1, new Guid("ff4a595a-760e-4fc7-bf12-ab4c8e483f50"), new Guid("958935ff-88c6-49a7-9cf3-83ad17184928") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarInfos",
                keyColumn: "Id",
                keyValue: new Guid("4a7369e2-49b0-4a32-aa8c-d11bb88c89e7"));

            migrationBuilder.DeleteData(
                table: "CarInfos",
                keyColumn: "Id",
                keyValue: new Guid("7f824107-38ac-4dee-a3e9-1039680c1c94"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("a29c60d4-a443-4972-af8a-7ce0e0e21b3f"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("d2037dba-188d-42e2-85f2-f7168111e38d"));

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "CarInfos",
                columns: new[] { "Id", "Brand", "CarType", "Description", "Engine", "EngineDisplacement", "FuelConsumption", "HorsePower", "ImageUrl", "Mileage", "Model", "PriceForSale", "Transmission", "Weight" },
                values: new object[,]
                {
                    { new Guid("42ac5131-54a9-4dd0-9d10-6bb8110fd728"), "Fiat", "Hatchback", "A quick hatchback with a lot of space.", 0, 1.4f, 7.5f, 105, "https://www.auto-data.net/images/f117/Fiat-Punto-Evo-199.jpg", 75000, "Punto Evo", 10000, 0, 1060 },
                    { new Guid("6c0dc587-e1db-4194-8b15-1007f8b3bd1e"), "Audi", "Sedan", "An old but fast classic sedan.", 0, 2.6f, 8.6f, 150, "https://www.auto-data.net/images/f87/Audi-80-V-B4-Typ-8C.jpg", 200000, "80 B4", 16000, 0, 1330 },
                    { new Guid("b5ec81b8-d35e-47c8-a812-7b16b4bbe63b"), "Citroen", "Minivan", "A really good family car with low fuel consumption.", 1, 2f, 5.5f, 90, "https://cdn3.focus.bg/autodata/i/citroen/xsara/xsara-picasso-n68/large/93f808a9cfb5a399babc04e50f54eb36.jpg", 150000, "Xsara Picasso", 7000, 0, 1300 }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "ApplicationUserId", "BuyerId", "CarDealerId", "CarInfoId", "SellerId" },
                values: new object[,]
                {
                    { new Guid("5bf7c130-c1c6-4f20-bc46-e3606645b6f0"), null, null, 1, new Guid("ff4a595a-760e-4fc7-bf12-ab4c8e483f50"), new Guid("958935ff-88c6-49a7-9cf3-83ad17184928") },
                    { new Guid("bfd49b07-74a0-4ad6-b7e1-9b97efd3764f"), null, null, 2, new Guid("4c139448-ccdc-4f58-b58a-7b8cb20ced4e"), new Guid("47cecf13-b028-4b4e-990e-6676609b8c8b") },
                    { new Guid("bfd7f2c1-e2e3-4ded-8345-1b76fa0a0830"), null, null, 2, new Guid("223c38c9-9842-452c-867d-31fbb4ab177d"), new Guid("47cecf13-b028-4b4e-990e-6676609b8c8b") }
                });
        }
    }
}
