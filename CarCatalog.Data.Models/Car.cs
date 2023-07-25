using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarCatalog.Data.Models
{
    public class Car
    {
        public Car()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(CarInfo))]
        public Guid CarInfoId { get; set; }

        public virtual CarInfo CarInfo { get; set; } = null!;

        [ForeignKey(nameof(Buyer))]
        public Guid? BuyerId { get; set; }

        public virtual CarBuyer? Buyer { get; set; }

        [ForeignKey(nameof(Seller))]
        public Guid SellerId { get; set; }

        public virtual CarSeller Seller { get; set; } = null!;

        [ForeignKey(nameof(Dealer))]
        public int CarDealerId { get; set; }

        public virtual CarDealer Dealer { get; set; } = null!;
    }
}
