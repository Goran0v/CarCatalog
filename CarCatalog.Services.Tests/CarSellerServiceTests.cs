using CarCatalog.Services.Data;
using CarCatalog.Services.Data.Interfaces;
using CarCatalog.Web.Data;
using Microsoft.EntityFrameworkCore;
using static CarCatalog.Services.Tests.DatabaseSeeder;

namespace CarCatalog.Services.Tests
{
    public class CarSellerServiceTests
    {
        private DbContextOptions<CarCatalogDbContext> dbOptions;
        private CarCatalogDbContext dbContext;
        private ICarSellerService carSellerService;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            this.dbOptions = new DbContextOptionsBuilder<CarCatalogDbContext>()
                .UseInMemoryDatabase("CarCatalogInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new CarCatalogDbContext(this.dbOptions);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.carSellerService = new CarSellerService(dbContext);
        }

        [Test]
        public async Task CarSellerExistsByUserIdAsyncShouldReturnTrueWhenExists()
        {
            string existingSellerUserId = CarSellerUser.Id.ToString();

            bool result = await this.carSellerService.CarSellerExistsByUserIdAsync(existingSellerUserId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task CarSellerExistsByUserIdAsyncShouldReturnFalseWhenDoesNotExists()
        {
            string existingSellerUserId = CarBuyerUser.Id.ToString();

            bool result = await this.carSellerService.CarSellerExistsByUserIdAsync(existingSellerUserId);

            Assert.IsFalse(result);
        }
    }
}