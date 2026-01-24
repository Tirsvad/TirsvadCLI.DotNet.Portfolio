using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TirsvadCLI.Portfolio.Infrastructure.Data;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        string? envConnectionString = Environment.GetEnvironmentVariable("CONNECTIONSTRINGS__DEFAULTCONNECTION");
        if (string.IsNullOrWhiteSpace(envConnectionString))
        {
            envConnectionString = "Host=localhost;Port=5434;Database=portfolio;Username=postgres;Password=postgres";
        }
        DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder = new();
        _ = optionsBuilder.UseNpgsql(envConnectionString);
        return new ApplicationDbContext(optionsBuilder.Options);
    }
}

