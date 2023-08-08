using System.ComponentModel.DataAnnotations;
using static CarCatalog.Common.EntityValidationConstants.CarValidations;

namespace CarCatalog.Web.ViewModels.Car
{
    public class CarAllViewModel
    {
        public string Id { get; set; } = null!;

        public string Brand { get; set; } = null!;

        public string Model { get; set; } = null!;

        [Display(Name = "Car Type")]
        public string CarType { get; set; } = null!;

        public int HorsePower { get; set; }

        [Display(Name = "Engine Displacement")]
        public float EngineDisplacement { get; set; }

        public int Mileage { get; set; }

        public int Weight { get; set; }

        [Display(Name = "Fuel Consumption")]
        public float FuelConsumption { get; set; }

        [Display(Name = "Price")]
        public int PriceForSale { get; set; }

        [Display(Name = "Transmission Type")]
        public TransmissionType Transmission { get; set; }

        [Display(Name = "Engine Type")]
        public EngineType Engine { get; set; }

        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string CarDealerName { get; set; } = null!;
    }
}
