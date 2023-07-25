using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CarCatalog.Common.EntityValidationConstants.CarValidations;

namespace CarCatalog.Data.Models
{
    public class CarInfo
    {
        public CarInfo()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(BrandMaxValue)]
        public string Brand { get; set; } = null!;

        [Required]
        [MaxLength(ModelMaxValue)]
        public string Model { get; set; } = null!;

        [Required]
        [MaxLength(CarTypeMaxValue)]
        public string CarType { get; set; } = null!;

        public int HorsePower { get; set; }

        public float EngineDisplacement { get; set; }

        public int Mileage { get; set; }

        public int Weight { get; set; }

        public float FuelConsumption { get; set; }

        public int PriceForSale { get; set; }

        public TransmissionType Transmission { get; set; }

        public EngineType Engine { get; set; }

        [Required]
        [MaxLength(ImageUrlMaxValue)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxValue)]
        public string Description { get; set; } = null!;

        [ForeignKey(nameof(Car))]
        public Guid CarId { get; set; }

        public virtual Car Car { get; set; } = null!;
    }
}
