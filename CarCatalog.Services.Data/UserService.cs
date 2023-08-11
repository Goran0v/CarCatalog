using CarCatalog.Data.Models;
using CarCatalog.Services.Data.Interfaces;
using CarCatalog.Web.Data;
using CarCatalog.Web.ViewModels.User;
using HouseRentingSystem.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CarCatalog.Services.Data
{
    public class UserService : IUserService
    {
        private readonly CarCatalogDbContext dbContext;

        public UserService(CarCatalogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<UserViewModel>> AllAsync()
        {
            List<UserViewModel> allUsers = await this.dbContext
                .Users
                .Select(u => new UserViewModel()
                {
                    Id = u.Id.ToString(),
                    Email = u.Email,
                    FullName = $"{u.FirstName} {u.LastName}"
                })
                .ToListAsync();

            foreach (var user in allUsers)
            {
                CarSeller? seller = await this.dbContext
                    .CarSellers
                    .FirstOrDefaultAsync(cs => cs.UserId.ToString() == user.Id);

                if (seller != null)
                {
                    user.PhoneNumber = seller.PhoneNumber;
                }

                CarBuyer? buyer = await this.dbContext
                    .CarBuyers
                    .FirstOrDefaultAsync(cb => cb.UserId.ToString() == user.Id);

                if (buyer != null && seller == null)
                {
                    user.PhoneNumber = buyer.PhoneNumber;
                }

                if(buyer == null && seller == null)
                {
                    user.PhoneNumber = string.Empty;
                }
            }

            return allUsers;
        }

        public async Task<string?> GetFullNameByEmailAsync(string email)
        {
            ApplicationUser? user = await this.dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                return string.Empty;
            }

            return $"{user.FirstName} {user.LastName}";
        }

        public async Task<string> GetFullNameByIdAsync(string userId)
        {
            ApplicationUser? user = await this.dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id.ToString() == userId);

            if (user == null)
            {
                return String.Empty;
            }

            return $"{user.FirstName} {user.LastName}";
        }
    }
}
