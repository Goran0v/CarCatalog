using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarCatalog.Web.Data
{
    public class CarCatalogDbContext : IdentityDbContext
    {
        public CarCatalogDbContext(DbContextOptions<CarCatalogDbContext> options)
            : base(options)
        {
        }
    }
}