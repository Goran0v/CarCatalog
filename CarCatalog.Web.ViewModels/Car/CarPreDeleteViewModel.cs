using System.ComponentModel.DataAnnotations;

namespace CarCatalog.Web.ViewModels.Car
{
    public class CarPreDeleteViewModel
    {
        public string Brand { get; set; } = null!;

        public string Model { get; set; } = null!;

        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;

        [Display(Name = "Dealership")]
        public string CarDealerName { get; set; } = null!;
    }
}
