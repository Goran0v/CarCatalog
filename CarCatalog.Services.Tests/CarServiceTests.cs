using Microsoft.EntityFrameworkCore;
using CarCatalog.Services.Data;
using CarCatalog.Services.Data.Interfaces;
using CarCatalog.Web.Data;
using static CarCatalog.Services.Tests.DatabaseSeeder;

namespace CarCatalog.Services.Tests
{
    public class CarServiceTests
    {
        private DbContextOptions<CarCatalogDbContext> dbOptions;
        private CarCatalogDbContext dbContext;
        private ICarDealerService carDealerService;
        private ICarService carService;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            this.dbOptions = new DbContextOptionsBuilder<CarCatalogDbContext>()
                .UseInMemoryDatabase("CarCatalogInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new CarCatalogDbContext(this.dbOptions);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.carDealerService = new CarDealerService(dbContext);
            this.carService = new CarService(dbContext, this.carDealerService);
        }

        [Test]
        public async Task CarExistsByIdAsyncShouldReturnTrueWhenExists()
        {
            string carId = Car1.Id.ToString();

            bool result = await this.carService.CarExistsByIdAsync(carId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task CarExistsByIdAsyncShouldReturnFalseWhenNotExists()
        {
            string carId = CarInfo1.Id.ToString();

            bool result = await this.carService.CarExistsByIdAsync(carId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task IsCarBoughtAsyncShouldReturnTrueWhenBought()
        {
            string carId = Car1.Id.ToString();

            bool result = await this.carService.IsCarBoughtAsync(carId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task IsCarBoughtAsyncShouldReturnFalseWhenNotBought()
        {
            string carId = Car2.Id.ToString();

            bool result = await this.carService.IsCarBoughtAsync(carId);

            Assert.IsFalse(result);
        }
    }
}
