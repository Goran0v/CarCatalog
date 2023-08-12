using CarCatalog.Services.Data;
using CarCatalog.Services.Data.Interfaces;
using CarCatalog.Web.Data;
using Microsoft.EntityFrameworkCore;
using static CarCatalog.Services.Tests.DatabaseSeeder;

namespace CarCatalog.Services.Tests
{
    public class CarBuyerServiceTests
    {
        private DbContextOptions<CarCatalogDbContext> dbOptions;
        private CarCatalogDbContext dbContext;
        private ICarBuyerService carBuyerService;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            this.dbOptions = new DbContextOptionsBuilder<CarCatalogDbContext>()
                .UseInMemoryDatabase("CarCatalogInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new CarCatalogDbContext(this.dbOptions);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.carBuyerService = new CarBuyerService(dbContext);
        }

        [Test]
        public async Task CarBuyerExistsByUserIdAsyncShouldReturnTrueWhenExists()
        {
            string existingBuyerUserId = CarBuyerUser.Id.ToString();

            bool result = await this.carBuyerService.CarBuyerExistsByUserIdAsync(existingBuyerUserId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task CarBuyerExistsByUserIdAsyncShouldReturnFalseWhenDoesNotExists()
        {
            string existingBuyerUserId = CarSellerUser.Id.ToString();

            bool result = await this.carBuyerService.CarBuyerExistsByUserIdAsync(existingBuyerUserId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task CarBuyerExistsByPhoneNumberAsyncShouldReturnTrueWhenExists()
        {
            string phoneNumber = Buyer.PhoneNumber;

            bool result = await this.carBuyerService.CarBuyerExistsByPhoneNumberAsync(phoneNumber);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task CarBuyerExistsByPhoneNumberAsyncShouldReturnFalseWhenDoesNotExists()
        {
            string phoneNumber = Seller.PhoneNumber;

            bool result = await this.carBuyerService.CarBuyerExistsByPhoneNumberAsync(phoneNumber);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task CarBuyerExistsByUsernameAsyncShouldReturnTrueWhenExists()
        {
            string username = Buyer.Username;

            bool result = await this.carBuyerService.CarBuyerExistsByUsernameAsync(username);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task CarBuyerExistsByUsernameAsyncShouldReturnFalseWhenDoesNotExists()
        {
            string username = Seller.Username;

            bool result = await this.carBuyerService.CarBuyerExistsByUsernameAsync(username);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task GetCarBuyerUsernameByUserIdAsyncShouldReturnUsernameWhenTrue()
        {
            string username = Buyer.Username;

            string result = await this.carBuyerService.GetCarBuyerUsernameByUserIdAsync(CarBuyerUser.Id.ToString());

            Assert.That(username, Is.EqualTo(result));
        }

        [Test]
        public async Task GetCarBuyerUsernameByUserIdAsyncShouldNotReturnUsernameWhenFalse()
        {
            string username = Seller.Username;

            string result = await this.carBuyerService.GetCarBuyerUsernameByUserIdAsync(CarBuyerUser.Id.ToString());

            Assert.That(username, Is.Not.EqualTo(result));
        }

        [Test]
        public async Task GetBuyerIdByUserIdAsyncShouldReturnIdWhenTrue()
        {
            string id = Buyer.Id.ToString();

            string? result = await this.carBuyerService.GetBuyerIdByUserIdAsync(CarBuyerUser.Id.ToString());

            Assert.That(id, Is.EqualTo(result));
        }

        [Test]
        public async Task GetBuyerIdByUserIdAsyncShouldNotReturnIdWhenFalse()
        {
            string id = Seller.Id.ToString();

            string? result = await this.carBuyerService.GetBuyerIdByUserIdAsync(CarBuyerUser.Id.ToString());

            Assert.That(id, Is.Not.EqualTo(result));
        }
    }
}
