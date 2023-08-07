using CarCatalog.Services.Data.Interfaces;
using CarCatalog.Web.Infrastructure.Extensions;
using CarCatalog.Web.ViewModels.CarSeller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static CarCatalog.Common.NotificationMessagesConstants;

namespace CarCatalog.Web.Controllers
{
    [Authorize]
    public class CarSellerController : Controller
    {
        private readonly ICarSellerService carSellerService;

        public CarSellerController(ICarSellerService carSellerService)
        {
            this.carSellerService = carSellerService;
        }

        [HttpGet]
        public async Task<IActionResult> Enter()
        {
            string? userId = this.User.GetId();
            bool isSeller = await this.carSellerService.CarSellerExistsByUserIdAsync(userId!);

            if (isSeller)
            {
                this.TempData[ErrorMessage] = "You are already a seller!";

                return this.RedirectToAction("Index", "Home");
            }

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Enter(BecomeACarSellerFormModel model)
        {
            string? userId = this.User.GetId();
            bool isSeller = await this.carSellerService.CarSellerExistsByUserIdAsync(userId!);

            if (isSeller)
            {
                this.TempData[ErrorMessage] = "You are already a seller!";

                return this.RedirectToAction("Index", "Home");
            }

            bool isPhoneNumberTaken =
                await this.carSellerService.CarSellerExistsByPhoneNumberAsync(model.PhoneNumber);

            if (isPhoneNumberTaken)
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), "A car seller with the provided phone number already exists!");
            }

            bool isUsernameTaken =
                await this.carSellerService.CarSellerExistsByUsernameAsync(model.Username);

            if (isUsernameTaken)
            {
                ModelState.AddModelError(nameof(model.Username), "A car seller with the provided username already exists!");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            try
            {
                await this.carSellerService.CreateAsync(userId!, model);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "An unexpected error occured while registering you as a seller! Please try again later or contact an administrator.";
                return this.RedirectToAction("Index", "Home");
            }

            return this.RedirectToAction("Index", "Home");
        }
    }
}
