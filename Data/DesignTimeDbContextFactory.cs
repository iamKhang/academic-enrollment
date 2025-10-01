using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace UniversityRegistration.Data;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<UniversityRegistrationContext>
{
    public UniversityRegistrationContext CreateDbContext(string[] args)
    {
        var basePath = Directory.GetCurrentDirectory();

        var configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        var connectionString = configuration.GetConnectionString("Default")
                               ?? throw new InvalidOperationException("Connection string 'Default' not found.");

        var optionsBuilder = new DbContextOptionsBuilder<UniversityRegistrationContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new UniversityRegistrationContext(optionsBuilder.Options);
    }
}
