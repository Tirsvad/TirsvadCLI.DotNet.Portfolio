using Microsoft.EntityFrameworkCore;

namespace TirsvadCLI.Portfolio.Infrastructure.Data;

public static class DbContextOptionsFactory
{
    public static DbContextOptions<ApplicationDbContext> Create(string? connectionString = default)
    {
        string? envConnectionString = Environment.GetEnvironmentVariable("CONNECTIONSTRINGS__DEFAULTCONNECTION");
        return !string.IsNullOrEmpty(envConnectionString)
            ? OptionsBuilder(envConnectionString)
            : connectionString is not null
                ? OptionsBuilder(connectionString)
                : OptionsBuilder("Data Source=localhost;Port=5434;Initial Catalog=portfolio;Username=postgres;Password=postgres");
        throw new NotSupportedException("DbContextOptionsFactory.Create() is only supported in DEBUG builds.");
    }

    private static DbContextOptions<ApplicationDbContext> OptionsBuilder(string connectionString)
    {
        DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder = new();
        _ = optionsBuilder.UseNpgsql(connectionString);
        return optionsBuilder.Options;
    }
}
