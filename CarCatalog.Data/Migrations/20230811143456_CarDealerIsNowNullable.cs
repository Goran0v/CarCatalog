using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarCatalog.Data.Migrations
{
    public partial class CarDealerIsNowNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "CarDealerId",
                table: "Cars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "CarInfos",
                columns: new[] { "Id", "Brand", "CarType", "Description", "Engine", "EngineDisplacement", "FuelConsumption", "HorsePower", "ImageUrl", "Mileage", "Model", "PriceForSale", "Transmission", "Weight" },
                values: new object[,]
                {
                    { new Guid("0bfde9b6-f712-492b-8cb1-d16b39b9775e"), "Audi", "Sedan", "An old but fast classic sedan.", 0, 2.6f, 8.6f, 150, "https://www.auto-data.net/images/f87/Audi-80-V-B4-Typ-8C.jpg", 200000, "80 B4", 16000, 0, 1330 },
                    { new Guid("af6b913d-e0d4-4fec-9c84-39ada31a0e93"), "Citroen", "Minivan", "A really good family car with low fuel consumption.", 1, 2f, 5.5f, 90, "https://cdn3.focus.bg/autodata/i/citroen/xsara/xsara-picasso-n68/large/93f808a9cfb5a399babc04e50f54eb36.jpg", 150000, "Xsara Picasso", 7000, 0, 1300 }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "ApplicationUserId", "BuyerId", "CarDealerId", "CarInfoId", "SellerId" },
                values: new object[,]
                {
                    { new Guid("a69af158-fe7d-4b2a-a65d-c5ba07d38cf8"), null, null, 2, new Guid("223c38c9-9842-452c-867d-31fbb4ab177d"), new Guid("47cecf13-b028-4b4e-990e-6676609b8c8b") },
                    { new Guid("efabc313-cfbc-492b-b7a1-15e1310b5e44"), null, null, 1, new Guid("ff4a595a-760e-4fc7-bf12-ab4c8e483f50"), new Guid("958935ff-88c6-49a7-9cf3-83ad17184928") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarInfos",
                keyColumn: "Id",
                keyValue: new Guid("0bfde9b6-f712-492b-8cb1-d16b39b9775e"));

            migrationBuilder.DeleteData(
                table: "CarInfos",
                keyColumn: "Id",
                keyValue: new Guid("af6b913d-e0d4-4fec-9c84-39ada31a0e93"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("a69af158-fe7d-4b2a-a65d-c5ba07d38cf8"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("efabc313-cfbc-492b-b7a1-15e1310b5e44"));

            migrationBuilder.AlterColumn<int>(
                name: "CarDealerId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
