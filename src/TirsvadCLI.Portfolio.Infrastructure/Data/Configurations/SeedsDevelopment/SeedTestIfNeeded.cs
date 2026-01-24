using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TirsvadCLI.Portfolio.Domain.Entities;

namespace TirsvadCLI.Portfolio.Infrastructure.Data.Configurations.SeedsDevelopment;

public class SeedTestIfNeeded
{
    public static void SeedTestUser(EntityTypeBuilder<ApplicationUser> builder)
    {
        // Precomputed hash for password 'Test@1234' using ASP.NET Core Identity v7+ (for ApplicationUser)
        // If you change the password, recompute the hash using the same Identity version and user properties.
        ApplicationUser user = new()
        {
            Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            UserName = "testuser",
            NormalizedUserName = "TESTUSER",
            Email = "testuser@example.com",
            NormalizedEmail = "TESTUSER@EXAMPLE.COM",
            EmailConfirmed = true,
            SecurityStamp = "11111111-1111-1111-1111-111111111112",
            ConcurrencyStamp = "11111111-1111-1111-1111-111111111113",
            PasswordHash = "AQAAAAEAACcQAAAAEJQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQw==" // Hash for password 'Test1234#'
        };

        _ = builder.HasData(user);
    }
}
