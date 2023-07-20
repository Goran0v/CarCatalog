using System.ComponentModel.DataAnnotations;
using static CarCatalog.Common.EntityValidationConstants.CarBuyerValidations;

namespace CarCatalog.Data.Models
{
    public class CarBuyer
    {
        public CarBuyer()
        {
            this.Id = Guid.NewGuid();
            this.CarsBought = new HashSet<Car>();
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

        public virtual ICollection<Car> CarsBought { get; set; } = null!;
    }
}
