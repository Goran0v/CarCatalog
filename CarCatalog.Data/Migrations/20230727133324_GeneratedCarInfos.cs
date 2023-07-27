using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarCatalog.Data.Migrations
{
    public partial class GeneratedCarInfos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CarInfos",
                columns: new[] { "Id", "Brand", "CarType", "Description", "Engine", "EngineDisplacement", "FuelConsumption", "HorsePower", "ImageUrl", "Mileage", "Model", "PriceForSale", "Transmission", "Weight" },
                values: new object[] { new Guid("223c38c9-9842-452c-867d-31fbb4ab177d"), "Audi", "Sedan", "An old but fast classic sedan.", 0, 2.6f, 8.6f, 150, "https://www.auto-data.net/images/f87/Audi-80-V-B4-Typ-8C.jpg", 200000, "80 B4", 16000, 0, 1330 });

            migrationBuilder.InsertData(
                table: "CarInfos",
                columns: new[] { "Id", "Brand", "CarType", "Description", "Engine", "EngineDisplacement", "FuelConsumption", "HorsePower", "ImageUrl", "Mileage", "Model", "PriceForSale", "Transmission", "Weight" },
                values: new object[] { new Guid("4c139448-ccdc-4f58-b58a-7b8cb20ced4e"), "Fiat", "Hatchback", "A quick hatchback with a lot of space.", 0, 1.4f, 7.5f, 105, "https://www.auto-data.net/images/f117/Fiat-Punto-Evo-199.jpg", 75000, "Punto Evo", 10000, 0, 1060 });

            migrationBuilder.InsertData(
                table: "CarInfos",
                columns: new[] { "Id", "Brand", "CarType", "Description", "Engine", "EngineDisplacement", "FuelConsumption", "HorsePower", "ImageUrl", "Mileage", "Model", "PriceForSale", "Transmission", "Weight" },
                values: new object[] { new Guid("ff4a595a-760e-4fc7-bf12-ab4c8e483f50"), "Citroen", "Minivan", "A really good family car with low fuel consumption.", 1, 2f, 5.5f, 90, "https://cdn3.focus.bg/autodata/i/citroen/xsara/xsara-picasso-n68/large/93f808a9cfb5a399babc04e50f54eb36.jpg", 150000, "Xsara Picasso", 7000, 0, 1300 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarInfos",
                keyColumn: "Id",
                keyValue: new Guid("223c38c9-9842-452c-867d-31fbb4ab177d"));

            migrationBuilder.DeleteData(
                table: "CarInfos",
                keyColumn: "Id",
                keyValue: new Guid("4c139448-ccdc-4f58-b58a-7b8cb20ced4e"));

            migrationBuilder.DeleteData(
                table: "CarInfos",
                keyColumn: "Id",
                keyValue: new Guid("ff4a595a-760e-4fc7-bf12-ab4c8e483f50"));
        }
    }
}
