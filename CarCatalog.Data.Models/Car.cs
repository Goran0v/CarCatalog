using System.ComponentModel.DataAnnotations;
using static CarCatalog.Common.EntityValidationConstants.CarValidations;

namespace CarCatalog.Data.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        public Guid CarInfoId { get; set; }

        public virtual CarInfo CarInfo { get; set; } = null!;

        public Guid? BuyerId { get; set; }

        public virtual CarBuyer? Buyer { get; set; }

        public Guid SellerId { get; set; }

        public virtual CarSeller Seller { get; set; } = null!;

        public int CarDealerId { get; set; }

        public virtual CarDealer Dealer { get; set; } = null!;
    }
}
