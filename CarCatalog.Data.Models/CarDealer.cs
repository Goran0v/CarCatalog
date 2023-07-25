using System.ComponentModel.DataAnnotations;
using static CarCatalog.Common.EntityValidationConstants.CarDealerValidations;

namespace CarCatalog.Data.Models
{
    public class CarDealer
    {
        public CarDealer()
        {
            this.RegisteredCars = new HashSet<Car>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxValue)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(AddressMaxValue)]
        public string Address { get; set; } = null!;

        public string? Description { get; set; }

        [Required]
        [MaxLength(PhoneNumberMaxValue)]
        public string PhoneNumber { get; set; } = null!;

        public virtual ICollection<Car> RegisteredCars { get; set; } = null!;
    }
}
