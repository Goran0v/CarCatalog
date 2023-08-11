using Microsoft.AspNetCore.Mvc;

namespace CarCatalog.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
