using System.ComponentModel.DataAnnotations;
using static CarCatalog.Common.EntityValidationConstants.User;

namespace CarCatalog.Web.ViewModels.User
{
    public class RegisterFormModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(PasswordMaxValue, MinimumLength = PasswordMinValue, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = null!;

        [Required]
        [StringLength(FirstNameMaxValue, MinimumLength = FirstNameMinValue)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(LastNameMaxValue, MinimumLength = LastNameMinValue)]
        public string LastName { get; set; } = null!;
    }
}
