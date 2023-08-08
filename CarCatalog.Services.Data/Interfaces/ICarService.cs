using CarCatalog.Web.ViewModels.Car;
using CarCatalog.Web.ViewModels.Home;

namespace CarCatalog.Services.Data.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<IndexViewModel>> AllCarsAsync();

        Task<string> CreateAndReturnIdAsync(CarFormModel formModel, string sellerId);

        Task<IEnumerable<CarAllViewModel>> AllCarsBySellerIdAsync(string sellerId);

        Task<IEnumerable<CarAllViewModel>> AllCarsByBuyerIdAsync(string buyerId);

        Task<CarDetailsViewModel> GetCarDetailsByIdAsync(string carId);
    }
}
