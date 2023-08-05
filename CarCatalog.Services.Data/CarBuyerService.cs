using CarCatalog.Data.Models;
using CarCatalog.Services.Data.Interfaces;
using CarCatalog.Web.Data;
using CarCatalog.Web.ViewModels.CarBuyer;
using Microsoft.EntityFrameworkCore;

namespace CarCatalog.Services.Data
{
    public class CarBuyerService : ICarBuyerService
    {
        private readonly CarCatalogDbContext dbContext;

        public CarBuyerService(CarCatalogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> CarBuyerExistsByPhoneNumberAsync(string phoneNumber)
        {
            bool result = await dbContext
                .CarBuyers
                .AnyAsync(cb => cb.PhoneNumber == phoneNumber);

            return result;
        }

        public async Task<bool> CarBuyerExistsByUserIdAsync(string userId)
        {
            bool result = await dbContext
                .CarBuyers
                .AnyAsync(cb => cb.UserId.ToString() == userId);

            return result;
        }

        public async Task<bool> CarBuyerExistsByUsernameAsync(string username)
        {
            bool result = await dbContext
                .CarBuyers
                .AnyAsync(cb => cb.Username == username);

            return result;
        }

        public async Task CreateAsync(string userId, BecomeACarBuyerFormModel model)
        {
            CarBuyer buyer = new CarBuyer()
            {
                UserId = Guid.Parse(userId),
                Username = model.Username,
                PhoneNumber = model.PhoneNumber
            };

            await dbContext.CarBuyers.AddAsync(buyer);
            await dbContext.SaveChangesAsync();
        }
    }
}
