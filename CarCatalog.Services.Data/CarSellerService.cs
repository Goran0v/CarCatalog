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

        public async Task<string?> GetSellerIdByUserIdAsync(string userId)
        {
            CarSeller? seller = await this.dbContext.CarSellers
                .FirstOrDefaultAsync(s => s.UserId.ToString() == userId);
            if (seller == null)
            {
                return null;
            }

            return seller.Id.ToString();
        }

        public async Task<bool> HasACarWithIdAsync(string userId, string carId)
        {
            CarSeller? seller = await this.dbContext
                .CarSellers
                .Include(cs => cs.CarsAvailable)
                .FirstOrDefaultAsync(cs => cs.UserId.ToString() == userId);

            if (seller == null)
            {
                return false;
            }

            carId = carId.ToLower();
            return seller.CarsAvailable.Any(c => c.Id.ToString() == carId);
        }
    }
}
