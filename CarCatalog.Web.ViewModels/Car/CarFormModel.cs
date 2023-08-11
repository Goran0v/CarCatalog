using System.ComponentModel.DataAnnotations;
using static CarCatalog.Common.EntityValidationConstants.CarValidations;
using static CarCatalog.Common.EntityValidationConstants.CarDealerValidations;

namespace CarCatalog.Web.ViewModels.Car
{
    public class CarFormModel
    {
        [Required]
        [StringLength(BrandMaxValue, MinimumLength = BrandMinValue)]
        public string Brand { get; set; } = null!;

        [Required]
        [StringLength(ModelMaxValue, MinimumLength = ModelMinValue)]
        public string Model { get; set; } = null!;

        [Required]
        [StringLength(CarTypeMaxValue, MinimumLength = CarTypeMinValue)]
        [Display(Name = "Car Type")]
        public string CarType { get; set; } = null!;

        [Range(typeof(int), HorsepowerMinValue, HorsepowerMaxValue)]
        public int HorsePower { get; set; }

        [Range(typeof(float), EngineDisplacementMinValue, EngineDisplacementMaxValue)]
        [Display(Name = "Engine Displacement")]
        public float EngineDisplacement { get; set; }

        [Range(typeof(int), MileageMinValue, MileageMaxValue)]
        public int Mileage { get; set; }

        [Range(typeof(int), WeightMinValue, WeightMaxValue)]
        public int Weight { get; set; }

        [Range(typeof(float), FuelConsumptionMinValue, FuelConsumptionMaxValue)]
        [Display(Name = "Fuel Consumption")]
        public float FuelConsumption { get; set; }

        [Range(typeof(int), PriceMinValue, PriceMaxValue)]
        [Display(Name = "Price")]
        public int PriceForSale { get; set; }

        [Display(Name = "Transmission Type")]
        public TransmissionType Transmission { get; set; }

        [Display(Name = "Engine Type")]
        public EngineType Engine { get; set; }

        [Required]
        [MaxLength(ImageUrlMaxValue)]
        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxValue)]
        public string Description { get; set; } = null!;

        [StringLength(NameMaxValue, MinimumLength = NameMinValue)]
        public string? CarDealerName { get; set; }
    }
}
