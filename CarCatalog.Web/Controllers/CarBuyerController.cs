using CarCatalog.Services.Data.Interfaces;
using CarCatalog.Web.Infrastructure.Extensions;
using CarCatalog.Web.ViewModels.CarBuyer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static CarCatalog.Common.NotificationMessagesConstants;

namespace CarCatalog.Web.Controllers
{
    [Authorize]
    public class CarBuyerController : Controller
    {
        private readonly ICarBuyerService carBuyerService;

        public CarBuyerController(ICarBuyerService carBuyerService)
        {
            this.carBuyerService = carBuyerService;
        }

        [HttpGet]
        public async Task<IActionResult> Enter()
        {
            string? userId = this.User.GetId();
            bool isBuyer = await this.carBuyerService.CarBuyerExistsByUserIdAsync(userId!);

            if (isBuyer)
            {
                this.TempData[ErrorMessage] = "You are already a buyer!";

                return this.RedirectToAction("Index", "Home");
            }

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Enter(BecomeACarBuyerFormModel model)
        {
            string? userId = this.User.GetId();
            bool isBuyer = await this.carBuyerService.CarBuyerExistsByUserIdAsync(userId!);

            if (isBuyer)
            {
                this.TempData[ErrorMessage] = "You are already a buyer!";

                return this.RedirectToAction("Index", "Home");
            }

            bool isPhoneNumberTaken = 
                await this.carBuyerService.CarBuyerExistsByPhoneNumberAsync(model.PhoneNumber);

            if (isPhoneNumberTaken)
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), "A car buyer with the provided phone number already exists!");
            }

            bool isUsernameTaken = 
                await this.carBuyerService.CarBuyerExistsByUsernameAsync(model.Username);

            if (isUsernameTaken)
            {
                ModelState.AddModelError(nameof(model.Username), "A car buyer with the provided username already exists!");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            try
            {
                await this.carBuyerService.CreateAsync(userId!, model);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "An unexpected error occured while registering you as a buyer! Please try again later or contact an administrator.";
                return this.RedirectToAction("Index", "Home");
            }

            return this.RedirectToAction("Index", "Home");
        }
    }
}
