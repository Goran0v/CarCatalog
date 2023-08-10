using CarCatalog.Web.ViewModels.CarBuyer;

namespace CarCatalog.Services.Data.Interfaces
{
    public interface ICarBuyerService
    {
        Task<string> GetCarBuyerUsernameByUserIdAsync(string userId);

        Task<bool> CarBuyerExistsByUserIdAsync(string userId);

        Task<bool> CarBuyerExistsByPhoneNumberAsync(string phoneNumber);

        Task<bool> CarBuyerExistsByUsernameAsync(string username);

        Task CreateAsync(string userId, BecomeACarBuyerFormModel model);

        Task<string?> GetBuyerIdByUserIdAsync(string userId);
    }
}