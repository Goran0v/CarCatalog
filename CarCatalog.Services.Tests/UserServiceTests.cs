using CarCatalog.Services.Data.Interfaces;
using CarCatalog.Services.Data;
using CarCatalog.Web.Data;
using Microsoft.EntityFrameworkCore;
using static CarCatalog.Services.Tests.DatabaseSeeder;

namespace CarCatalog.Services.Tests
{
    public class UserServiceTests
    {
        private DbContextOptions<CarCatalogDbContext> dbOptions;
        private CarCatalogDbContext dbContext;
        private IUserService userService;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            this.dbOptions = new DbContextOptionsBuilder<CarCatalogDbContext>()
                .UseInMemoryDatabase("CarCatalogInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new CarCatalogDbContext(this.dbOptions);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.userService = new UserService(dbContext);
        }

        [Test]
        public async Task GetFullNameByEmailAsyncShouldReturnFullNameWhenTrue()
        {
            string fullName = $"{CarSellerUser.FirstName} {CarSellerUser.LastName}";

            string? result = await this.userService.GetFullNameByEmailAsync(CarSellerUser.Email);

            Assert.That(fullName, Is.EqualTo(result));
        }

        [Test]
        public async Task GetFullNameByEmailAsyncShouldNotReturnFullNameWhenFalse()
        {
            string fullName = $"{CarBuyerUser.FirstName} {CarBuyerUser.LastName}";

            string? result = await this.userService.GetFullNameByEmailAsync(CarSellerUser.Email);

            Assert.That(fullName, Is.Not.EqualTo(result));
        }

        [Test]
        public async Task GetFullNameByIdAsyncShouldReturnFullNameWhenTrue()
        {
            string fullName = $"{CarSellerUser.FirstName} {CarSellerUser.LastName}";

            string? result = await this.userService.GetFullNameByIdAsync(CarSellerUser.Id.ToString());

            Assert.That(fullName, Is.EqualTo(result));
        }

        [Test]
        public async Task GetFullNameByIdAsyncShouldNotReturnFullNameWhenFalse()
        {
            string fullName = $"{CarBuyerUser.FirstName} {CarBuyerUser.LastName}";

            string? result = await this.userService.GetFullNameByIdAsync(CarSellerUser.Id.ToString());

            Assert.That(fullName, Is.Not.EqualTo(result));
        }
    }
}