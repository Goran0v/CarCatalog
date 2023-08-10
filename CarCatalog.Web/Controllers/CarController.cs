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
        private readonly ICarBuyerService carBuyerService;
        private readonly ICarDealerService carDealerService;

        public CarController(ICarService carService, ICarSellerService carSellerService, ICarDealerService carDealerService, ICarBuyerService carBuyerService)
        {
            this.carService = carService;
            this.carSellerService = carSellerService;
            this.carDealerService = carDealerService;
            this.carBuyerService = carBuyerService;
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

        [HttpGet]
        public async Task<IActionResult> CarsForSale()
        {
            List<CarAllViewModel> myCars = new List<CarAllViewModel>();

            string userId = this.User.GetId()!;

            string? sellerId = await this.carSellerService.GetSellerIdByUserIdAsync(userId);

            myCars.AddRange(await this.carService.AllCarsBySellerIdAsync(sellerId!));

            return this.View(myCars);
        }

        [HttpGet]
        public async Task<IActionResult> CarsBought()
        {
            List<CarAllViewModel> myCars = new List<CarAllViewModel>();

            string userId = this.User.GetId()!;

            string? buyerId = await this.carBuyerService.GetBuyerIdByUserIdAsync(userId);

            myCars.AddRange(await this.carService.AllCarsByBuyerIdAsync(buyerId!));

            return this.View(myCars);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            bool carExists = await this.carService.CarExistsByIdAsync(id);

            if (!carExists)
            {
                this.TempData[ErrorMessage] = "The car with the provided id does not exist";

                return this.RedirectToAction("Index", "Home");
            }

            try
            {
                CarDetailsViewModel? viewModel = await this.carService
                    .GetCarDetailsByIdAsync(id);

                return View(viewModel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            bool carExists = await this.carService
                .CarExistsByIdAsync(id);

            if (!carExists)
            {
                this.TempData[ErrorMessage] = "The car with the provided id does not exist";
                return this.RedirectToAction("Index", "Home");
            }

            bool isUserSeller = await this.carSellerService
                .CarSellerExistsByUserIdAsync(this.User.GetId()!);

            if (!isUserSeller)
            {
                this.TempData[ErrorMessage] = "You must be a seller in order to edit house info";
                return this.RedirectToAction("Enter", "CarSeller");
            }

            string? sellerId = await this.carSellerService.GetSellerIdByUserIdAsync(this.User.GetId()!);
            bool isSellerOwner = await this.carSellerService.HasACarWithIdAsync(this.User.GetId()!, id);

            if (!isSellerOwner)
            {
                this.TempData[ErrorMessage] = "You must be the owner of the car if you want to edit it!";
                return this.RedirectToAction("CarsForSale", "Car");
            }

            try
            {
                CarFormModel formModel = await this.carService.GetCarForEditByIdAsync(id);

                return this.View(formModel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, CarFormModel formModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(formModel);
            }

            bool carExists = await this.carService
                .CarExistsByIdAsync(id);

            if (!carExists)
            {
                this.TempData[ErrorMessage] = "The car with the provided id does not exist";
                return this.RedirectToAction("Index", "Home");
            }

            bool isUserSeller = await this.carSellerService
                .CarSellerExistsByUserIdAsync(this.User.GetId()!);

            if (!isUserSeller)
            {
                this.TempData[ErrorMessage] = "You must be a seller in order to edit house info";
                return this.RedirectToAction("Enter", "CarSeller");
            }

            string? sellerId = await this.carSellerService.GetSellerIdByUserIdAsync(this.User.GetId()!);
            bool isSellerOwner = await this.carSellerService.HasACarWithIdAsync(this.User.GetId()!, id);

            if (!isSellerOwner)
            {
                this.TempData[ErrorMessage] = "You must be the owner of the car if you want to edit it!";
                return this.RedirectToAction("CarsForSale", "Car");
            }

            try
            {
                await this.carService.EditCarByIdAndFormModelAsync(id, formModel);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "An unexpected error ocurred while trying to update this car. Please try again later or contact an administratror!");

                return this.View(formModel);
            }

            return this.RedirectToAction("Details", "Car", new { id });
        }

        private IActionResult GeneralError()
        {
            this.TempData[ErrorMessage] = "An unexpected error ocurred. Please try again later or contact an administratror!";
            return this.RedirectToAction("Index", "Home");
        }
    }
}
