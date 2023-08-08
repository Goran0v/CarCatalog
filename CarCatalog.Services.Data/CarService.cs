﻿using CarCatalog.Data.Models;
using CarCatalog.Services.Data.Interfaces;
using CarCatalog.Web.Data;
using CarCatalog.Web.ViewModels.Car;
using CarCatalog.Web.ViewModels.CarSeller;
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

        public async Task<IEnumerable<CarAllViewModel>> AllCarsByBuyerIdAsync(string buyerId)
        {
            IEnumerable<CarAllViewModel> allBuyerCars = await this.dbContext
                .Cars
                .Where(c => c.BuyerId.ToString() == buyerId)
                .Select(c => new CarAllViewModel()
                {
                    Id = c.Id.ToString(),
                    Brand = c.CarInfo.Brand,
                    Model = c.CarInfo.Model,
                    CarType = c.CarInfo.CarType,
                    HorsePower = c.CarInfo.HorsePower,
                    EngineDisplacement = c.CarInfo.EngineDisplacement,
                    Mileage = c.CarInfo.Mileage,
                    Weight = c.CarInfo.Weight,
                    FuelConsumption = c.CarInfo.FuelConsumption,
                    PriceForSale = c.CarInfo.PriceForSale,
                    Transmission = c.CarInfo.Transmission,
                    Engine = c.CarInfo.Engine,
                    ImageUrl = c.CarInfo.ImageUrl,
                    Description = c.CarInfo.Description,
                    CarDealerName = c.Dealer.Name
                })
                .ToArrayAsync();

            return allBuyerCars;
        }

        public async Task<IEnumerable<CarAllViewModel>> AllCarsBySellerIdAsync(string sellerId)
        {
            IEnumerable<CarAllViewModel> allSellerCars = await this.dbContext
                .Cars
                .Where(c => c.SellerId.ToString() == sellerId)
                .Select(c => new CarAllViewModel()
                {
                    Id = c.Id.ToString(),
                    Brand = c.CarInfo.Brand,
                    Model = c.CarInfo.Model,
                    CarType = c.CarInfo.CarType,
                    HorsePower = c.CarInfo.HorsePower,
                    EngineDisplacement = c.CarInfo.EngineDisplacement,
                    Mileage = c.CarInfo.Mileage,
                    Weight = c.CarInfo.Weight,
                    FuelConsumption = c.CarInfo.FuelConsumption,
                    PriceForSale = c.CarInfo.PriceForSale,
                    Transmission = c.CarInfo.Transmission,
                    Engine = c.CarInfo.Engine,
                    ImageUrl = c.CarInfo.ImageUrl,
                    Description = c.CarInfo.Description,
                    CarDealerName = c.Dealer.Name
                })
                .ToArrayAsync();

            return allSellerCars;
        }

        public async Task<bool> CarExistsByIdAsync(string carId)
        {
            bool result = await this.dbContext
                .Cars
                .AnyAsync(c => c.Id.ToString() == carId);

            return result;
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

        public async Task<CarDetailsViewModel?> GetCarDetailsByIdAsync(string carId)
        {
            Car? car = await this.dbContext
                .Cars
                .FirstOrDefaultAsync(c => c.Id.ToString() == carId);

            if (car == null)
            {
                return null;
            }

            string sellerId = car.SellerId.ToString();
            CarSeller seller = await this.dbContext.CarSellers.FirstAsync(cs => cs.Id.ToString() == sellerId);
            CarInfo carInfo = await this.dbContext.CarInfos.FirstAsync(ci => ci.Id == car.CarInfoId);
            CarDealer dealer = await this.dbContext.CarDealers.FirstAsync(d => d.Id == car.CarDealerId);

            return new CarDetailsViewModel()
            {
                Id = car!.Id.ToString(),
                Brand = carInfo.Brand,
                Model = carInfo.Model,
                CarType = carInfo.CarType,
                HorsePower = carInfo.HorsePower,
                EngineDisplacement = carInfo.EngineDisplacement,
                Mileage = carInfo.Mileage,
                Weight = carInfo.Weight,
                FuelConsumption = carInfo.FuelConsumption,
                PriceForSale = carInfo.PriceForSale,
                Transmission = carInfo.Transmission,
                Engine = carInfo.Engine,
                ImageUrl = carInfo.ImageUrl,
                Description = carInfo.Description,
                CarDealerName = dealer.Name,
                Seller = new CarSellerInfoOnCarViewModel()
                {
                    Username = seller.Username,
                    PhoneNumber = seller.PhoneNumber,
                    Address = seller.Address
                }
            };
        }
    }
}