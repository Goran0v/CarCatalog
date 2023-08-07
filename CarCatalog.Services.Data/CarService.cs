using CarCatalog.Data.Models;
using CarCatalog.Services.Data.Interfaces;
using CarCatalog.Web.Data;
using CarCatalog.Web.ViewModels.Car;
using CarCatalog.Web.ViewModels.Home;
using Microsoft.EntityFrameworkCore;

namespace CarCatalog.Services.Data
{
    public class CarService : ICarService
    {
        private readonly CarCatalogDbContext dbContext;
        private readonly ICarDealerService carDealerService;

        public CarService(CarCatalogDbContext dbContext, ICarDealerService carDealerService)
        {
            this.dbContext = dbContext;
            this.carDealerService = carDealerService;
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

        public async Task<string> CreateAndReturnIdAsync(CarFormModel formModel, string sellerId)
        {
            CarInfo carInfo = new CarInfo()
            {
                Brand = formModel.Brand,
                Model = formModel.Model,
                CarType = formModel.CarType,
                HorsePower = formModel.HorsePower,
                EngineDisplacement = formModel.EngineDisplacement,
                Mileage = formModel.Mileage,
                Weight = formModel.Weight,
                FuelConsumption = formModel.FuelConsumption,
                PriceForSale = formModel.PriceForSale,
                Transmission = formModel.Transmission,
                Engine = formModel.Engine,
                ImageUrl = formModel.ImageUrl,
                Description = formModel.Description
            };

            int carDealerId = (int)await this.carDealerService.GetIdOfDealershipByNameAsync(formModel.CarDealerName);

            Car car = new Car()
            {
                CarInfoId = carInfo.Id,
                BuyerId = null,
                SellerId = Guid.Parse(sellerId),
                CarDealerId = carDealerId
            };

            await this.dbContext.CarInfos.AddAsync(carInfo);
            await this.dbContext.Cars.AddAsync(car);
            CarSeller seller = await this.dbContext.CarSellers.FirstAsync(cs => cs.Id == Guid.Parse(sellerId));
            seller.CarsAvailable.Add(car);
            car.Dealer.RegisteredCars.Add(car);
            await this.dbContext.SaveChangesAsync();

            return car.Id.ToString();
        }
    }
}