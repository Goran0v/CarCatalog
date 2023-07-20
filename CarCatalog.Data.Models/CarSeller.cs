using System.ComponentModel.DataAnnotations;
using static CarCatalog.Common.EntityValidationConstants.CarSellerValidations;

namespace CarCatalog.Data.Models
{
    public class CarSeller
    {
        public CarSeller()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(UsernameMaxValue)]
        public string Username { get; set; } = null!;

        [Required]
        [MaxLength(PhoneNumberMaxValue)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [MaxLength(EmailMaxValue)]
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(AddressMaxValue)]
        public string Address { get; set; } = null!;
    }
}
