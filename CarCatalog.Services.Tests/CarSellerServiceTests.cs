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

        [Test]
        public async Task CarSellerExistsByPhoneNumberAsyncShouldReturnTrueWhenExists()
        {
            string phoneNumber = Seller.PhoneNumber;

            bool result = await this.carSellerService.CarSellerExistsByPhoneNumberAsync(phoneNumber);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task CarSellerExistsByPhoneNumberAsyncShouldReturnFalseWhenDoesNotExists()
        {
            string phoneNumber = Buyer.PhoneNumber;

            bool result = await this.carSellerService.CarSellerExistsByPhoneNumberAsync(phoneNumber);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task CarSellerExistsByUsernameAsyncShouldReturnTrueWhenExists()
        {
            string username = Seller.Username;

            bool result = await this.carSellerService.CarSellerExistsByUsernameAsync(username);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task CarSellerExistsByUsernameAsyncShouldReturnFalseWhenDoesNotExists()
        {
            string username = Buyer.Username;

            bool result = await this.carSellerService.CarSellerExistsByUsernameAsync(username);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task GetCarSellerUsernameByUserIdAsyncShouldReturnUsernameWhenTrue()
        {
            string username = Seller.Username;

            string result = await this.carSellerService.GetCarSellerUsernameByUserIdAsync(CarSellerUser.Id.ToString());

            Assert.That(username, Is.EqualTo(result));
        }

        [Test]
        public async Task GetCarSellerUsernameByUserIdAsyncShouldNotReturnUsernameWhenFalse()
        {
            string username = Buyer.Username;

            string result = await this.carSellerService.GetCarSellerUsernameByUserIdAsync(CarSellerUser.Id.ToString());

            Assert.That(username, Is.Not.EqualTo(result));
        }

        [Test]
        public async Task GetSellerIdByUserIdAsyncShouldReturnIdWhenTrue()
        {
            string id = Seller.Id.ToString();

            string? result = await this.carSellerService.GetSellerIdByUserIdAsync(CarSellerUser.Id.ToString());

            Assert.That(id, Is.EqualTo(result));
        }

        [Test]
        public async Task GetSellerIdByUserIdAsyncShouldNotReturnIdWhenFalse()
        {
            string id = Buyer.Id.ToString();

            string? result = await this.carSellerService.GetSellerIdByUserIdAsync(CarSellerUser.Id.ToString());

            Assert.That(id, Is.Not.EqualTo(result));
        }

        [Test]
        public async Task HasACarWithIdAsyncShouldReturnTrueWhenHas()
        {
            string id = CarSellerUser.Id.ToString();

            bool result = await this.carSellerService.HasACarWithIdAsync(id, Car.Id.ToString());

            Assert.IsTrue(result);
        }

        [Test]
        public async Task HasACarWithIdAsyncShouldReturnFalseWhenHasNot()
        {
            string id = CarBuyerUser.Id.ToString();

            bool result = await this.carSellerService.HasACarWithIdAsync(id, Car.Id.ToString());

            Assert.IsFalse(result);
        }
    }
}