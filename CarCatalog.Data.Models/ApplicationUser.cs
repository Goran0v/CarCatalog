using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static CarCatalog.Common.EntityValidationConstants.User;

namespace CarCatalog.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
            this.Cars = new HashSet<Car>();
        }

        [Required]
        [MaxLength(FirstNameMaxValue)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(LastNameMaxValue)]
        public string LastName { get; set; } = null!;

        public virtual ICollection<Car> Cars { get; set; } = null!;
    }
}
