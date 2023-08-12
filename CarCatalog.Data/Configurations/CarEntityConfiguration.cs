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
                CarInfoId = Guid.Parse("2B3DDEB5-446F-4AFA-BB05-2162992FDFD2"),
                BuyerId = null,
                SellerId = Guid.Parse("745AAD63-C004-483F-99F5-0B5C58E1A90A"),
                CarDealerId = 1
            };
            cars.Add(car);

            car = new Car()
            {
                CarInfoId = Guid.Parse("0BF82F3B-BF1B-4C01-A77D-43DBFCE6741D"),
                BuyerId = null,
                SellerId = Guid.Parse("47CECF13-B028-4B4E-990E-6676609B8C8B"),
                CarDealerId = 2
            };
            cars.Add(car);

            car = new Car()
            {
                CarInfoId = Guid.Parse("4895D66C-5F7D-4464-A3B3-4B88257BBF60"),
                BuyerId = null,
                SellerId = Guid.Parse("47CECF13-B028-4B4E-990E-6676609B8C8B"),
                CarDealerId = 3
            };
            cars.Add(car);

            car = new Car()
            {
                CarInfoId = Guid.Parse("32350C4C-D4CC-4A9F-83C5-FBA2F2593C7F"),
                BuyerId = null,
                SellerId = Guid.Parse("745AAD63-C004-483F-99F5-0B5C58E1A90A"),
                CarDealerId = 1
            };
            cars.Add(car);

            return cars.ToArray();
        }   
    }
}
