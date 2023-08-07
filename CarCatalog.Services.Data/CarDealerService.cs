using CarCatalog.Data.Models;
using CarCatalog.Services.Data.Interfaces;
using CarCatalog.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace CarCatalog.Services.Data
{
    public class CarDealerService : ICarDealerService
    {
        private readonly CarCatalogDbContext dbContext;

        public CarDealerService(CarCatalogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int?> GetIdOfDealershipByNameAsync(string name)
        {
            CarDealer? carDealer = await dbContext
                .CarDealers
                .FirstOrDefaultAsync(d => d.Name == name);

            if (carDealer == null)
            {
                return 0;
            }

            return carDealer.Id;
        }
    }
}
