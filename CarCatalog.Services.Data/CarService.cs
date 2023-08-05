using CarCatalog.Services.Data.Interfaces;
using CarCatalog.Web.Data;
using CarCatalog.Web.ViewModels.Home;
using Microsoft.EntityFrameworkCore;

namespace CarCatalog.Services.Data
{
    public class CarService : ICarService
    {
        private readonly CarCatalogDbContext dbContext;

        public CarService(CarCatalogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<IndexViewModel>> AllCarsAsync()
        {
            return await
                this.dbContext
                .Cars
                .Where(c => c.BuyerId.HasValue == false)
                .OrderByDescending(c => c.Id)
                .Select(c => new IndexViewModel()
                {
                    Id = c.Id.ToString(),
                    Brand = c.CarInfo.Brand,
                    Model = c.CarInfo.Model,
                    ImageUrl = c.CarInfo.ImageUrl
                })
                .ToArrayAsync();
        }
    }
}
