using Microsoft.EntityFrameworkCore;
using CarCatalog.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarCatalog.Data.Configurations
{
    public class CarDealerEntityConfiguration : IEntityTypeConfiguration<CarDealer>
    {
        public void Configure(EntityTypeBuilder<CarDealer> builder)
        {
            builder.HasData(this.GenerateCarDealers());
        }

        private CarDealer[] GenerateCarDealers()
        {
            ICollection<CarDealer> carDealers = new HashSet<CarDealer>();

            CarDealer carDealer;
            carDealer = new CarDealer()
            {
                Id = 1,
                Name = "Pleven Auto House",
                Address = "Pleven, Bulgaria",
                Description = "Selling good cars in Pleven",
                PhoneNumber = "+359877778888"
            };
            carDealers.Add(carDealer);

            carDealer = new CarDealer()
            {
                Id = 2,
                Name = "Sofia Auto House",
                Address = "Sofia, Bulgaria",
                Description = "Selling cheap cars in Sofia",
                PhoneNumber = "+359887778888"
            };
            carDealers.Add(carDealer);

            carDealer = new CarDealer()
            {
                Id = 3,
                Name = "Burgas Auto House",
                Address = "Burgas, Bulgaria",
                Description = "Selling good cars in Burgas",
                PhoneNumber = "+359897778888"
            };
            carDealers.Add(carDealer);

            return carDealers.ToArray();
        }
    }
}
