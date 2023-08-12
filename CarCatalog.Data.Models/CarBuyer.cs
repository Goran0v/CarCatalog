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

        public Guid UserId { get; set; }

        public virtual ApplicationUser User { get; set; } = null!;

        public virtual ICollection<Car> CarsBought { get; set; } = null!;
    }
}
