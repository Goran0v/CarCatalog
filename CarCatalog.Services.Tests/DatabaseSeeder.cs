using CarCatalog.Data.Models;
using CarCatalog.Web.Data;

namespace CarCatalog.Services.Tests
{
    public static class DatabaseSeeder
    {
        public static ApplicationUser CarSellerUser;
        public static ApplicationUser CarBuyerUser;
        public static CarSeller Seller;
        public static CarBuyer Buyer;
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

            dbContext.Users.Add(CarSellerUser);
            dbContext.Users.Add(CarBuyerUser);

            dbContext.CarSellers.Add(Seller);
            dbContext.CarBuyers.Add(Buyer);

            dbContext.SaveChanges();
        }
    }
}
