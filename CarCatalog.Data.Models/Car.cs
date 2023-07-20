using System.ComponentModel.DataAnnotations;
using static CarCatalog.Common.EntityValidationConstants.CarValidations;

namespace CarCatalog.Data.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

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

        public float FuelConsumption { get; set; }

        public int PriceForSale { get; set; }

        [Required]
        [MaxLength(ImageUrlMaxValue)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxValue)]
        public string? Description { get; set; }
    }
}
