using CarCatalog.Web.ViewModels.CarSeller;

namespace CarCatalog.Web.ViewModels.Car
{
    public class CarDetailsViewModel : CarAllViewModel
    {
        public CarSellerInfoOnCarViewModel Seller { get; set; } = null!;
    }
}
