using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarCatalog.Data.Migrations
{
    public partial class SeedCars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "SellerId",
                table: "Cars",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "ApplicationUserId", "BuyerId", "CarDealerId", "CarInfoId", "SellerId" },
                values: new object[,]
                {
                    { new Guid("0cf0dbd0-ad29-4652-b84e-6b753da4ed6d"), null, null, 1, new Guid("32350c4c-d4cc-4a9f-83c5-fba2f2593c7f"), new Guid("745aad63-c004-483f-99f5-0b5c58e1a90a") },
                    { new Guid("87baa5b2-cd1f-47a9-8668-0730bfbf6dfa"), null, null, 3, new Guid("4895d66c-5f7d-4464-a3b3-4b88257bbf60"), new Guid("47cecf13-b028-4b4e-990e-6676609b8c8b") },
                    { new Guid("9fc23d6a-e595-421b-809e-a566ef6e25ea"), null, null, 1, new Guid("2b3ddeb5-446f-4afa-bb05-2162992fdfd2"), new Guid("745aad63-c004-483f-99f5-0b5c58e1a90a") },
                    { new Guid("fcac869a-08c0-4531-a1c6-8664977e9e20"), null, null, 2, new Guid("0bf82f3b-bf1b-4c01-a77d-43dbfce6741d"), new Guid("47cecf13-b028-4b4e-990e-6676609b8c8b") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarInfos",
                keyColumn: "Id",
                keyValue: new Guid("98b1193a-2133-415f-aa10-9900d3da966b"));

            migrationBuilder.DeleteData(
                table: "CarInfos",
                keyColumn: "Id",
                keyValue: new Guid("a42bd30f-99ad-41f6-ad1a-6eab4de9365e"));

            migrationBuilder.DeleteData(
                table: "CarInfos",
                keyColumn: "Id",
                keyValue: new Guid("b8ac5972-5ecd-432a-bff4-8eb083659d45"));

            migrationBuilder.DeleteData(
                table: "CarInfos",
                keyColumn: "Id",
                keyValue: new Guid("dee17190-5d8f-4025-9a17-f76d1358de66"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("0cf0dbd0-ad29-4652-b84e-6b753da4ed6d"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("87baa5b2-cd1f-47a9-8668-0730bfbf6dfa"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("9fc23d6a-e595-421b-809e-a566ef6e25ea"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("fcac869a-08c0-4531-a1c6-8664977e9e20"));

            migrationBuilder.AlterColumn<Guid>(
                name: "SellerId",
                table: "Cars",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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
    }
}
