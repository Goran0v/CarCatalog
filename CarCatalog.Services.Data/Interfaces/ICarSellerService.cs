﻿using CarCatalog.Web.ViewModels.CarSeller;

namespace CarCatalog.Services.Data.Interfaces
{
    public interface ICarSellerService
    {
        Task<string> GetCarSellerUsernameByUserIdAsync(string userId);

        Task<bool> CarSellerExistsByUserIdAsync(string userId);

        Task<bool> CarSellerExistsByPhoneNumberAsync(string phoneNumber);

        Task<bool> CarSellerExistsByUsernameAsync(string username);

        Task CreateAsync(string userId, BecomeACarSellerFormModel model);

        Task<string?> GetSellerIdByUserIdAsync(string userId);

        Task<bool> HasACarWithIdAsync(string userId, string carId);
    }
}
