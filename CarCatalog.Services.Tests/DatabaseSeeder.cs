using CarCatalog.Data.Models;
using CarCatalog.Web.Data;
using static CarCatalog.Common.EntityValidationConstants.CarValidations;

namespace CarCatalog.Services.Tests
{
    public static class DatabaseSeeder
    {
        public static ApplicationUser CarSellerUser;
        public static ApplicationUser CarBuyerUser;
        public static CarSeller Seller;
        public static CarBuyer Buyer;
        public static CarInfo CarInfo;
        public static CarDealer CarDealer;
        public static Car Car;
        public static void SeedDatabase(CarCatalogDbContext dbContext)
        {
            CarSellerUser = new ApplicationUser()
            {
                UserName = "peshoTheCarBuyer@buyers.com",
                NormalizedUserName = "PESHOTHECARBUYER@BUYERS.COM",
                Email = "peshoTheCarBuyer@buyers.com",
                NormalizedEmail = "PESHOTHECARBUYER@BUYERS.COM",
                EmailConfirmed = false,
                PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                SecurityStamp = "0858aaca-15d8-4ee2-ba58-250679b63bec",
                ConcurrencyStamp = "47ec29c2-0b0f-48fb-8a39-7251b234d5bd",
                TwoFactorEnabled = false,
                FirstName = "Pesho",
                LastName = "Peshev"
            };
            CarBuyerUser = new ApplicationUser()
            {
                UserName = "goshoTheCarSeller@sellers.com",
                NormalizedUserName = "GOSHOTHECARSELLER@SELLERS.COM",
                Email = "goshoTheCarSeller@sellers.com",
                NormalizedEmail = "GOSHOTHECARSELLER@SELLERS.COM",
                EmailConfirmed = false,
                PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                SecurityStamp = "94e044e9-f6ae-406e-a41d-c4f7f9529431",
                ConcurrencyStamp = "d2910249-eb32-4890-870a-cbf1d9a4f1c8",
                TwoFactorEnabled = false,
                FirstName = "Gosho",
                LastName = "Goshev"
            };
            Seller = new CarSeller()
            {
                Username = "Pesho",
                PhoneNumber = "+359888888888",
                Address = "Ruse, Bulgaria",
                UserId = CarSellerUser.Id
            };
            Buyer = new CarBuyer()
            {
                Username = "Gosho",
                PhoneNumber = "+359999999999",
                UserId = CarBuyerUser.Id
            };

            CarInfo = new CarInfo()
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

            CarDealer = new CarDealer()
            {
                Id = 0,
                Name = "Burgas Auto House",
                Address = "Burgas, Bulgaria",
                Description = "Selling good cars in Burgas",
                PhoneNumber = "+359897778888"
            };

            Car = new Car()
            {
                CarInfoId = CarInfo.Id,
                BuyerId = null,
                SellerId = Seller.Id,
                CarDealerId = null
            };

            dbContext.Users.Add(CarSellerUser);
            dbContext.Users.Add(CarBuyerUser);

            dbContext.CarSellers.Add(Seller);
            dbContext.CarBuyers.Add(Buyer);

            dbContext.CarInfos.Add(CarInfo);
            dbContext.CarDealers.Add(CarDealer);
            Seller.CarsAvailable.Add(Car);
            dbContext.Cars.Add(Car);

            dbContext.SaveChanges();
        }
    }
}
