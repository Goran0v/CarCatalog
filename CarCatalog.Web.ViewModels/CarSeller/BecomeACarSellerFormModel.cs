using System.ComponentModel.DataAnnotations;
using static CarCatalog.Common.EntityValidationConstants.CarSellerValidations;

namespace CarCatalog.Web.ViewModels.CarSeller
{
    public class BecomeACarSellerFormModel
    {
        [Required]
        [StringLength(UsernameMaxValue, MinimumLength = UsernameMinValue)]
        public string Username { get; set; } = null!;

        [Required]
        [StringLength(PhoneNumberMaxValue, MinimumLength = PhoneNumberMinValue)]
        [Phone]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [StringLength(AddressMaxValue, MinimumLength = AddressMinValue)]
        public string Address { get; set; } = null!;
    }
}
