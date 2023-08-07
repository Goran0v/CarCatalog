using CarCatalog.Data.Models;
using CarCatalog.Services.Data.Interfaces;
using CarCatalog.Web.Data;
using CarCatalog.Web.ViewModels.CarSeller;
using Microsoft.EntityFrameworkCore;

namespace CarCatalog.Services.Data
{
    public class CarSellerService : ICarSellerService
    {
        private readonly CarCatalogDbContext dbContext;

        public CarSellerService(CarCatalogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> CarSellerExistsByPhoneNumberAsync(string phoneNumber)
        {
            bool result = await dbContext
                .CarSellers
                .AnyAsync(cs => cs.PhoneNumber == phoneNumber);

            return result;
        }

        public async Task<bool> CarSellerExistsByUserIdAsync(string userId)
        {
            bool result = await dbContext
                .CarSellers
                .AnyAsync(cs => cs.UserId.ToString() == userId);

            return result;
        }

        public async Task<bool> CarSellerExistsByUsernameAsync(string username)
        {
            bool result = await dbContext
                .CarSellers
                .AnyAsync(cs => cs.Username == username);

            return result;
        }

        public async Task CreateAsync(string userId, BecomeACarSellerFormModel model)
        {
            CarSeller seller = new CarSeller()
            {
                UserId = Guid.Parse(userId),
                Username = model.Username,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address
            };

            await dbContext.CarSellers.AddAsync(seller);
            await dbContext.SaveChangesAsync();
        }
    }
}
