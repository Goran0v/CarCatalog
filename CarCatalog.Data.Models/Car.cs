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

        public Guid? BuyerId { get; set; }

        public virtual CarBuyer? Buyer { get; set; }

        public Guid SellerId { get; set; }

        public virtual CarSeller Seller { get; set; } = null!;

        public int CarDealerId { get; set; }

        public virtual CarDealer Dealer { get; set; } = null!;
    }
}
