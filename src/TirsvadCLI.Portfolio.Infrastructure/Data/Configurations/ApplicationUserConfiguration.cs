using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TirsvadCLI.Portfolio.Domain.Entities;
using TirsvadCLI.Portfolio.Infrastructure.Data.Configurations.SeedsDevelopment;

namespace TirsvadCLI.Portfolio.Infrastructure.Data.Configurations;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
#if DEBUG
        SeedTestIfNeeded.SeedTestUser(builder);
#endif
    }
}
