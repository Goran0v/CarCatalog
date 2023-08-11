using System.ComponentModel.DataAnnotations;

namespace CarCatalog.Web.ViewModels.CarSeller
{
    public class CarSellerInfoOnCarViewModel
    {
        [Display(Name = "Full Name")]
        public string FullName { get; set; } = null!;

        public string Username { get; set; } = null!;

        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; } = null!;

        public string Address { get; set; } = null!;
    }
}
