using CarCatalog.Services.Data.Interfaces;
using CarCatalog.Web.Areas.Admin.ViewModels.Car;
using CarCatalog.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CarCatalog.Web.Areas.Admin.Controllers
{
    public class CarController : BaseAdminController
    {
        private readonly ICarSellerService carSellerService;
        private readonly ICarBuyerService carBuyerService;
        private readonly ICarService carService;

        public CarController(ICarSellerService carSellerService, ICarService carService, ICarBuyerService carBuyerService)
        {
            this.carSellerService = carSellerService;
            this.carService = carService;
            this.carBuyerService = carBuyerService;
        }

        public async Task<IActionResult> Mine()
        {
            string? sellerId = 
                await this.carSellerService.GetSellerIdByUserIdAsync(this.User.GetId()!);

            string? buyerId =
                await this.carBuyerService.GetBuyerIdByUserIdAsync(this.User.GetId()!);

            MyCarsViewModel viewModel = new MyCarsViewModel()
            {
                AddedCars = await this.carService.AllCarsBySellerIdAsync(sellerId!),
                CarsBought = await this.carService.AllCarsByBuyerIdAsync(buyerId!),
            };

            return this.View(viewModel);
        }
    }
}
