using CarCatalog.Data.Models;
using HouseRentingSystem.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CarCatalog.Web.Data
{
    public class CarCatalogDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public CarCatalogDbContext(DbContextOptions<CarCatalogDbContext> options)
            : base(options)
        {
        }

        public DbSet<CarInfo> CarInfos { get; set; } = null!;
        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<CarBuyer> CarBuyers { get; set; } = null!;
        public DbSet<CarSeller> CarSellers { get; set; } = null!;
        public DbSet<CarDealer> CarDealers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAssembly = Assembly.GetAssembly(typeof(CarCatalogDbContext)) ?? Assembly.GetExecutingAssembly();
            builder.ApplyConfigurationsFromAssembly(configAssembly);

            builder.Entity<Car>()
                .HasOne(c => c.CarInfo)
                .WithOne()
                .HasForeignKey<Car>(c => c.CarInfoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Car>()
                .HasOne(c => c.Buyer)
                .WithMany(b => b.CarsBought)
                .HasForeignKey(c => c.BuyerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Car>()
                .HasOne(c => c.Seller)
                .WithMany(s => s.CarsAvailable)
                .HasForeignKey(c => c.SellerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Car>()
                .HasOne(c => c.Dealer)
                .WithMany(d => d.RegisteredCars)
                .HasForeignKey(c => c.CarDealerId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}