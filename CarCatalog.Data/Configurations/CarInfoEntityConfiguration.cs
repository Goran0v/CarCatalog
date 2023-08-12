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
                Brand = "Subaru",
                Model = "Forester",
                CarType = "Crossover",
                HorsePower = 125,
                EngineDisplacement = 2.0f,
                Mileage = 100000,
                Weight = 1360,
                FuelConsumption = 8.5f,
                PriceForSale = 15000,
                Transmission = TransmissionType.Manual,
                Engine = EngineType.Gasoline,
                ImageUrl = "https://cdn3.focus.bg/autodata/i/subaru/forester/forester-ii/large/a942a400b16a08d5b5788147fea6325c.jpg",
                Description = "A good offroad car."
            };
            carInfos.Add(carInfo);

            carInfo = new CarInfo()
            {
                Brand = "Toyota",
                Model = "Corolla Hatch",
                CarType = "Hatchback",
                HorsePower = 86,
                EngineDisplacement = 1.3f,
                Mileage = 65000,
                Weight = 1060,
                FuelConsumption = 7.5f,
                PriceForSale = 8500,
                Transmission = TransmissionType.Manual,
                Engine = EngineType.Gasoline,
                ImageUrl = "https://www.auto-data.net/images/f106/Toyota-Corolla-Hatch-VIII-E110.jpg",
                Description = "A small car ideal for the city."
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
