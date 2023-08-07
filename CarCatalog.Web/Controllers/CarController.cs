using CarCatalog.Services.Data.Interfaces;
using CarCatalog.Web.Infrastructure.Extensions;
using CarCatalog.Web.ViewModels.Car;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static CarCatalog.Common.NotificationMessagesConstants;

namespace CarCatalog.Web.Controllers
{
    [Authorize]
    public class CarController : Controller
    {
        private readonly ICarService carService;
        private readonly ICarSellerService carSellerService;
        private readonly ICarDealerService carDealerService;

        public CarController(ICarService carService, ICarSellerService carSellerService, ICarDealerService carDealerService)
        {
            this.carService = carService;
            this.carSellerService = carSellerService;
            this.carDealerService = carDealerService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            bool isSeller = await carSellerService.CarSellerExistsByUserIdAsync(this.User.GetId()!);

            if (!isSeller)
            {
                this.TempData[ErrorMessage] = "You must be a seller in order to add new car ads!";
                return this.RedirectToAction("Enter", "CarSeller");
            }

            try
            {
                CarFormModel carFormModel = new CarFormModel();

                return View(carFormModel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(CarFormModel carModel)
        {
            bool isSeller = await carSellerService.CarSellerExistsByUserIdAsync(this.User.GetId()!);

            if (!isSeller)
            {
                this.TempData[ErrorMessage] = "You must be a seller in order to add new car ads!";
                return this.RedirectToAction("Enter", "CarSeller");
            }

            int? carDealerId = await carDealerService.GetIdOfDealershipByNameAsync(carModel.CarDealerName);

            if (carDealerId == null)
            {
                ModelState.AddModelError(nameof(carModel.CarDealerName), "The provided Dealership does not exist!");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(carModel);
            }

            try
            {
                string? sellerId = await this.carSellerService.GetSellerIdByUserIdAsync(this.User.GetId()!);
                string carId = await this.carService.CreateAndReturnIdAsync(carModel, sellerId!);
                return this.RedirectToAction("Index", "Home");
                //return this.RedirectToAction("Details", "Car", new { id = carId });
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "An unexpected error occured while trying to add your new car! Please try again later or contact an administrator!");
                return this.View(carModel);
            }
        }

        private IActionResult GeneralError()
        {
            this.TempData[ErrorMessage] = "An unexpected error ocurred. Please try again later or contact an administratror!";
            return this.RedirectToAction("Index", "Home");
        }
    }
}
