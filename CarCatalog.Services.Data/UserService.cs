using CarCatalog.Services.Data.Interfaces;
using CarCatalog.Web.Data;
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
    }
}
