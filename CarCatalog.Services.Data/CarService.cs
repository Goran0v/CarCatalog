using CarCatalog.Data.Models;
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

        public async Task BuyACarAsync(string carId, string userId)
        {
            Car car = await this.dbContext
                .Cars
                .Include(c => c.Dealer)
                .Include(c => c.Seller)
                .FirstAsync(c => c.Id.ToString() == carId);

            CarBuyer carBuyer = await this.dbContext
                .CarBuyers
                .FirstAsync(cb => cb.UserId.ToString() == userId);

            CarSeller seller = await this.dbContext
                .CarSellers
                .FirstAsync(cs => cs.Id == car.SellerId);

            CarDealer dealer = await this.dbContext
                .CarDealers
                .FirstAsync(cd => cd.Id == car.CarDealerId);

            carBuyer.CarsBought.Add(car);
            car.Buyer = carBuyer;
            //car.Seller.UserId = Guid.Parse(userId);
            //seller.CarsAvailable.Remove(car);
            //dealer.RegisteredCars.Remove(car);

            //Have to fix this

            await this.dbContext.SaveChangesAsync();
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

            int? carDealerId = (int)await this.carDealerService.GetIdOfDealershipByNameAsync(formModel.CarDealerName);

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
            if (car.CarDealerId.HasValue)
            {
                car.Dealer!.RegisteredCars.Add(car);
            }
            await this.dbContext.SaveChangesAsync();

            return car.Id.ToString();
        }

        public async Task DeleteCarByIdAsync(string id)
        {
            Car carToDelete = await this.dbContext
                .Cars
                .FirstAsync(c => c.Id.ToString() == id);

            CarSeller seller = await this.dbContext.CarSellers.FirstAsync(cs => cs.CarsAvailable.Contains(carToDelete));
            seller.CarsAvailable.Remove(carToDelete);
            CarDealer dealer = await this.dbContext.CarDealers.FirstAsync(cd => cd.RegisteredCars.Contains(carToDelete));
            dealer.RegisteredCars.Remove(carToDelete);
            CarInfo info = await this.dbContext.CarInfos.FirstAsync(ci => ci.Id == carToDelete.CarInfoId);
            this.dbContext.CarInfos.Remove(info);
            this.dbContext.Cars.Remove(carToDelete);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task EditCarByIdAndFormModelAsync(string id, CarFormModel model)
        {
            Car car = await this.dbContext
                .Cars
                .Include(c => c.CarInfo)
                .Include(c => c.Dealer)
                .FirstAsync(c => c.Id.ToString() == id);

            car.CarInfo.Brand = model.Brand;
            car.CarInfo.Model = model.Model;
            car.CarInfo.CarType = model.CarType;
            car.CarInfo.EngineDisplacement = model.EngineDisplacement;
            car.CarInfo.Mileage = model.Mileage;
            car.CarInfo.Weight = model.Weight;
            car.CarInfo.FuelConsumption = model.FuelConsumption;
            car.CarInfo.PriceForSale = model.PriceForSale;
            car.CarInfo.Transmission = model.Transmission;
            car.CarInfo.Engine = model.Engine;
            car.CarInfo.ImageUrl = model.ImageUrl;
            car.CarInfo.Description = model.Description;
            car.Dealer.Name = model.CarDealerName;

            await this.dbContext.SaveChangesAsync();
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

        public async Task<CarPreDeleteViewModel> GetCarForDeleteByIdAsync(string id)
        {
            Car car = await this.dbContext
                .Cars
                .Include(c => c.CarInfo)
                .Include(c => c.Dealer)
                .FirstAsync(c => c.Id.ToString() == id);

            return new CarPreDeleteViewModel()
            {
                Brand = car.CarInfo.Brand,
                Model = car.CarInfo.Model,
                ImageUrl = car.CarInfo.ImageUrl,
                CarDealerName = car.Dealer.Name
            };
        }

        public async Task<CarFormModel> GetCarForEditByIdAsync(string carId)
        {
            Car car = await this.dbContext
                .Cars
                .Include(c => c.CarInfo)
                .Include(c => c.Dealer)
                .FirstAsync(c => c.Id.ToString() == carId);

            return new CarFormModel()
            {
                Brand = car.CarInfo.Brand,
                Model = car.CarInfo.Model,
                CarType = car.CarInfo.CarType,
                HorsePower = car.CarInfo.HorsePower,
                EngineDisplacement = car.CarInfo.EngineDisplacement,
                Mileage = car.CarInfo.Mileage,
                Weight = car.CarInfo.Weight,
                FuelConsumption = car.CarInfo.FuelConsumption,
                PriceForSale = car.CarInfo.PriceForSale,
                Transmission = car.CarInfo.Transmission,
                Engine = car.CarInfo.Engine,
                ImageUrl = car.CarInfo.ImageUrl,
                Description = car.CarInfo.Description,
                CarDealerName = car.Dealer.Name,
            };
        }

        public async Task<bool> IsCarBoughtAsync(string carId)
        {
            Car car = await this.dbContext
                .Cars
                .FirstAsync(c => c.Id.ToString() == carId);

            return car.BuyerId.HasValue;
        }

        public async Task<CarSellFormModel> SellABoughtCar(string carId, string userId)
        {
            Car car = await this.dbContext
                .Cars
                .Include(c => c.CarInfo)
                .Include(c => c.Dealer)
                .FirstAsync(c => c.Id.ToString() == carId);

            CarSeller seller = await this.dbContext.CarSellers.FirstAsync(cs => cs.UserId == Guid.Parse(userId));
            seller.CarsAvailable.Add(car);
            CarBuyer buyer = await this.dbContext.CarBuyers.FirstAsync(cb => cb.Id == car.BuyerId);
            buyer.CarsBought.Remove(car);
            car.Dealer.RegisteredCars.Add(car);

            await this.dbContext.SaveChangesAsync();

            return new CarSellFormModel()
            {
                Id = car.Id.ToString(),
                Brand = car.CarInfo.Brand,
                Model = car.CarInfo.Model,
                CarType = car.CarInfo.CarType,
                HorsePower = car.CarInfo.HorsePower,
                EngineDisplacement = car.CarInfo.EngineDisplacement,
                Mileage = car.CarInfo.Mileage,
                Weight = car.CarInfo.Weight,
                FuelConsumption = car.CarInfo.FuelConsumption,
                PriceForSale = car.CarInfo.PriceForSale,
                Transmission = car.CarInfo.Transmission,
                Engine = car.CarInfo.Engine,
                ImageUrl = car.CarInfo.ImageUrl,
                Description = car.CarInfo.Description,
                CarDealerName = car.Dealer.Name
            };
        }
    }
}