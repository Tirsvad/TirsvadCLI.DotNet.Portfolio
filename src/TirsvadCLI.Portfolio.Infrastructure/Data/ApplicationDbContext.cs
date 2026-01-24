using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;

using TirsvadCLI.Portfolio.Domain.Entities;
using TirsvadCLI.Portfolio.Infrastructure.Data.Configurations;

namespace TirsvadCLI.Portfolio.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    #region constructors
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    #endregion

    #region overrides
    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Apply ApplicationUser configuration (see Configurations/ApplicationUserConfiguration.cs)
        _ = modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
        // Apply ClientCertificate configuration (see Configurations/ClientCertificateConfiguration.cs)
        //_ = modelBuilder.ApplyConfiguration(new ClientCertificateConfiguration());
    }
    #endregion

}
