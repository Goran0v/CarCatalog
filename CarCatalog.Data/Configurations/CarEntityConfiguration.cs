using CarCatalog.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarCatalog.Data.Configurations
{
    public class CarEntityConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasData(this.GenerateCars());
        }

        private Car[] GenerateCars()
        {
            ICollection<Car> cars = new HashSet<Car>();

            Car car;
            car = new Car()
            {
                CarInfoId = Guid.Parse("FF4A595A-760E-4FC7-BF12-AB4C8E483F50"),
                BuyerId = null,
                SellerId = Guid.Parse("958935FF-88C6-49A7-9CF3-83AD17184928"),
                CarDealerId = 1
            };
            cars.Add(car);

            car = new Car()
            {
                CarInfoId = Guid.Parse("4C139448-CCDC-4F58-B58A-7B8CB20CED4E"),
                BuyerId = null,
                SellerId = Guid.Parse("47CECF13-B028-4B4E-990E-6676609B8C8B"),
                CarDealerId = 2
            };
            cars.Add(car);

            car = new Car()
            {
                CarInfoId = Guid.Parse("223C38C9-9842-452C-867D-31FBB4AB177D"),
                BuyerId = null,
                SellerId = Guid.Parse("47CECF13-B028-4B4E-990E-6676609B8C8B"),
                CarDealerId = 2
            };
            cars.Add(car);

            return cars.ToArray();
        }
    }
}
