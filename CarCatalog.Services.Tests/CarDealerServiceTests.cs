using CarCatalog.Services.Data;
using CarCatalog.Services.Data.Interfaces;
using CarCatalog.Web.Data;
using Microsoft.EntityFrameworkCore;
using static CarCatalog.Services.Tests.DatabaseSeeder;

namespace CarCatalog.Services.Tests
{
    public class CarDealerServiceTests
    {
        private DbContextOptions<CarCatalogDbContext> dbOptions;
        private CarCatalogDbContext dbContext;
        private ICarDealerService carDealerService;

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
        }

        [Test]
        public async Task GetCarDealerIdByNameAsyncShouldReturnIdWhenTrue()
        {
            int id = CarDealer.Id - 1;

            int? result = await this.carDealerService.GetIdOfDealershipByNameAsync(CarDealer.Name);

            Assert.That(id, Is.EqualTo(result));
        }

        [Test]
        public async Task GetCarDealerIdByNameAsyncShouldNotReturnIdWhenFalse()
        {
            int falseId = 6;

            int? result = await this.carDealerService.GetIdOfDealershipByNameAsync(CarDealer.Name);

            Assert.That(falseId, Is.Not.EqualTo(result));
        }
    }
}
