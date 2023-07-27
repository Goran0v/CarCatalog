using CarCatalog.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static CarCatalog.Common.EntityValidationConstants.CarValidations;

namespace CarCatalog.Data.Configurations
{
    public class CarInfoEntityConfiguration : IEntityTypeConfiguration<CarInfo>
    {
        public void Configure(EntityTypeBuilder<CarInfo> builder)
        {
            builder.HasData(this.GenerateCarInfos());
        }

        private CarInfo[] GenerateCarInfos()
        {
            ICollection<CarInfo> carInfos = new HashSet<CarInfo>();

            CarInfo carInfo;
            carInfo = new CarInfo()
            {
                Brand = "Citroen",
                Model = "Xsara Picasso",
                CarType = "Minivan",
                HorsePower = 90,
                EngineDisplacement = 2.0f,
                Mileage = 150000,
                Weight = 1300,
                FuelConsumption = 5.5f,
                PriceForSale = 7000,
                Transmission = TransmissionType.Manual,
                Engine = EngineType.Diesel,
                ImageUrl = "https://cdn3.focus.bg/autodata/i/citroen/xsara/xsara-picasso-n68/large/93f808a9cfb5a399babc04e50f54eb36.jpg",
                Description = "A really good family car with low fuel consumption."
            };
            carInfos.Add(carInfo);

            carInfo = new CarInfo()
            {
                Brand = "Fiat",
                Model = "Punto Evo",
                CarType = "Hatchback",
                HorsePower = 105,
                EngineDisplacement = 1.4f,
                Mileage = 75000,
                Weight = 1060,
                FuelConsumption = 7.5f,
                PriceForSale = 10000,
                Transmission = TransmissionType.Manual,
                Engine = EngineType.Gasoline,
                ImageUrl = "https://www.auto-data.net/images/f117/Fiat-Punto-Evo-199.jpg",
                Description = "A quick hatchback with a lot of space."
            };
            carInfos.Add(carInfo);

            carInfo = new CarInfo()
            {
                Brand = "Audi",
                Model = "80 B4",
                CarType = "Sedan",
                HorsePower = 150,
                EngineDisplacement = 2.6f,
                Mileage = 200000,
                Weight = 1330,
                FuelConsumption = 8.6f,
                PriceForSale = 16000,
                Transmission = TransmissionType.Manual,
                Engine = EngineType.Gasoline,
                ImageUrl = "https://www.auto-data.net/images/f87/Audi-80-V-B4-Typ-8C.jpg",
                Description = "An old but fast classic sedan."
            };
            carInfos.Add(carInfo);

            return carInfos.ToArray();
        }
    }
}
