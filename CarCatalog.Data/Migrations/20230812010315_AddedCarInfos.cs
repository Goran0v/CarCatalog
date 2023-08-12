using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarCatalog.Data.Migrations
{
    public partial class AddedCarInfos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarInfos",
                keyColumn: "Id",
                keyValue: new Guid("0f004ff1-4b62-433f-8ed2-58714c132f50"));

            migrationBuilder.DeleteData(
                table: "CarInfos",
                keyColumn: "Id",
                keyValue: new Guid("340329e3-5040-4206-b918-3d90f5a2fe49"));

            migrationBuilder.DeleteData(
                table: "CarInfos",
                keyColumn: "Id",
                keyValue: new Guid("b30b46aa-fcef-430b-9e28-eb243dadab2b"));

            migrationBuilder.DeleteData(
                table: "CarInfos",
                keyColumn: "Id",
                keyValue: new Guid("eb98ba74-1e4a-4c1e-b3bd-05b67a1ded77"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("5c2c0b67-65ea-4099-833f-1413d98ab304"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("6f4d5277-925b-4d94-8e48-55ce1ed26424"));

            migrationBuilder.InsertData(
                table: "CarInfos",
                columns: new[] { "Id", "Brand", "CarType", "Description", "Engine", "EngineDisplacement", "FuelConsumption", "HorsePower", "ImageUrl", "Mileage", "Model", "PriceForSale", "Transmission", "Weight" },
                values: new object[,]
                {
                    { new Guid("0bf82f3b-bf1b-4c01-a77d-43dbfce6741d"), "Subaru", "Crossover", "A good offroad car.", 0, 2f, 8.5f, 125, "https://cdn3.focus.bg/autodata/i/subaru/forester/forester-ii/large/a942a400b16a08d5b5788147fea6325c.jpg", 100000, "Forester", 15000, 0, 1360 },
                    { new Guid("2b3ddeb5-446f-4afa-bb05-2162992fdfd2"), "Toyota", "Hatchback", "A small car ideal for the city.", 0, 1.3f, 7.5f, 86, "https://www.auto-data.net/images/f106/Toyota-Corolla-Hatch-VIII-E110.jpg", 65000, "Corolla Hatch", 8500, 0, 1060 },
                    { new Guid("32350c4c-d4cc-4a9f-83c5-fba2f2593c7f"), "Citroen", "Minivan", "A really good family car with low fuel consumption.", 1, 2f, 5.5f, 90, "https://cdn3.focus.bg/autodata/i/citroen/xsara/xsara-picasso-n68/large/93f808a9cfb5a399babc04e50f54eb36.jpg", 150000, "Xsara Picasso", 7000, 0, 1300 },
                    { new Guid("4895d66c-5f7d-4464-a3b3-4b88257bbf60"), "Audi", "Sedan", "An old but fast classic sedan.", 0, 2.6f, 8.6f, 150, "https://www.auto-data.net/images/f87/Audi-80-V-B4-Typ-8C.jpg", 200000, "80 B4", 16000, 0, 1330 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarInfos",
                keyColumn: "Id",
                keyValue: new Guid("0bf82f3b-bf1b-4c01-a77d-43dbfce6741d"));

            migrationBuilder.DeleteData(
                table: "CarInfos",
                keyColumn: "Id",
                keyValue: new Guid("2b3ddeb5-446f-4afa-bb05-2162992fdfd2"));

            migrationBuilder.DeleteData(
                table: "CarInfos",
                keyColumn: "Id",
                keyValue: new Guid("32350c4c-d4cc-4a9f-83c5-fba2f2593c7f"));

            migrationBuilder.DeleteData(
                table: "CarInfos",
                keyColumn: "Id",
                keyValue: new Guid("4895d66c-5f7d-4464-a3b3-4b88257bbf60"));

            migrationBuilder.InsertData(
                table: "CarInfos",
                columns: new[] { "Id", "Brand", "CarType", "Description", "Engine", "EngineDisplacement", "FuelConsumption", "HorsePower", "ImageUrl", "Mileage", "Model", "PriceForSale", "Transmission", "Weight" },
                values: new object[,]
                {
                    { new Guid("0f004ff1-4b62-433f-8ed2-58714c132f50"), "Audi", "Sedan", "An old but fast classic sedan.", 0, 2.6f, 8.6f, 150, "https://www.auto-data.net/images/f87/Audi-80-V-B4-Typ-8C.jpg", 200000, "80 B4", 16000, 0, 1330 },
                    { new Guid("340329e3-5040-4206-b918-3d90f5a2fe49"), "Toyota", "Hatchback", "A small car ideal for the city.", 0, 1.3f, 7.5f, 86, "https://www.auto-data.net/images/f106/Toyota-Corolla-Hatch-VIII-E110.jpg", 65000, "Corolla Hatch", 8500, 0, 1060 },
                    { new Guid("b30b46aa-fcef-430b-9e28-eb243dadab2b"), "Subaru", "Crossover", "A good offroad car.", 0, 2f, 8.5f, 125, "https://cdn3.focus.bg/autodata/i/subaru/forester/forester-ii/large/a942a400b16a08d5b5788147fea6325c.jpg", 100000, "Forester", 15000, 0, 1360 },
                    { new Guid("eb98ba74-1e4a-4c1e-b3bd-05b67a1ded77"), "Citroen", "Minivan", "A really good family car with low fuel consumption.", 1, 2f, 5.5f, 90, "https://cdn3.focus.bg/autodata/i/citroen/xsara/xsara-picasso-n68/large/93f808a9cfb5a399babc04e50f54eb36.jpg", 150000, "Xsara Picasso", 7000, 0, 1300 }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "ApplicationUserId", "BuyerId", "CarDealerId", "CarInfoId", "SellerId" },
                values: new object[,]
                {
                    { new Guid("5c2c0b67-65ea-4099-833f-1413d98ab304"), null, null, 1, new Guid("ff4a595a-760e-4fc7-bf12-ab4c8e483f50"), new Guid("958935ff-88c6-49a7-9cf3-83ad17184928") },
                    { new Guid("6f4d5277-925b-4d94-8e48-55ce1ed26424"), null, null, 2, new Guid("223c38c9-9842-452c-867d-31fbb4ab177d"), new Guid("47cecf13-b028-4b4e-990e-6676609b8c8b") }
                });
        }
    }
}
