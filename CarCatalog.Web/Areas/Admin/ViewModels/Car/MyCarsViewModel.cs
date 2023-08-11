using CarCatalog.Web.ViewModels.Car;

namespace CarCatalog.Web.Areas.Admin.ViewModels.Car
{
    public class MyCarsViewModel
    {
        public IEnumerable<CarAllViewModel> AddedCars { get; set; } = null!;

        public IEnumerable<CarAllViewModel> CarsBought { get; set; } = null!;
    }
}
