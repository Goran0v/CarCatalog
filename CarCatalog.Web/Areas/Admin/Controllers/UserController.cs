using CarCatalog.Services.Data.Interfaces;
using CarCatalog.Web.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace CarCatalog.Web.Areas.Admin.Controllers
{
    public class UserController : BaseAdminController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [Route("User/All")]
        public async Task<IActionResult> All()
        {
            IEnumerable<UserViewModel> viewModel = 
                await this.userService.AllAsync();
            return this.View(viewModel);
        }
    }
}
