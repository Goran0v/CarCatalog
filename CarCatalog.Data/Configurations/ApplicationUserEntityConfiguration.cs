using Microsoft.EntityFrameworkCore;
using CarCatalog.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarCatalog.Data.Configurations
{
    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder
                .Property(u => u.FirstName)
                .HasDefaultValue("Test");

            builder
                .Property(u => u.LastName)
                .HasDefaultValue("Testov");
        }
    }
}
