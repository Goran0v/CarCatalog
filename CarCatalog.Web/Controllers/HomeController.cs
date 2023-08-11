using CarCatalog.Services.Data.Interfaces;
using CarCatalog.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarCatalog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarService carService;

        public HomeController(ICarService carService)
        {
            this.carService = carService;
        }

        public async Task<IActionResult> Index()
        {
            var cars = await carService.AllCarsAsync();
            return View(cars);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400 || statusCode == 404)
            {
                return View("Error404");
            }

            if (statusCode == 401)
            {
                return View("Error401");
            }

            return this.View();
        }
    }
}