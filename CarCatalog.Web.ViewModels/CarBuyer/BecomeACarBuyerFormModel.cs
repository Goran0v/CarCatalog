using System.ComponentModel.DataAnnotations;
using static CarCatalog.Common.EntityValidationConstants.CarBuyerValidations;

namespace CarCatalog.Web.ViewModels.CarBuyer
{
    public class BecomeACarBuyerFormModel
    {
        [Required]
        [StringLength(UsernameMaxValue, MinimumLength = UsernameMinValue)]
        public string Username { get; set; } = null!;

        [Required]
        [StringLength(PhoneNumberMaxValue, MinimumLength = PhoneNumberMinValue)]
        [Phone]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; } = null!;
    }
}
