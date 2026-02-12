using Bookify.Application.Abstractions.Clock;
using Bookify.Application.Abstractions.Email;
using Bookify.infrastructure.Clock;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bookify.infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();
        services.AddTransient<IEmailService, IEmailService>();
        
        var connectionString = configuration.GetConnectionString("Database")??
                               throw new ArgumentNullException(nameof(configuration));
        
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
        });
        return services;
    }
    
}