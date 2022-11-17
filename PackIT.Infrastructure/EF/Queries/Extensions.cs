using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PackIT.Shared.Queries;

namespace PackIT.Infrastructure.EF.Queries;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSqlServerConnection(configuration);
        services.AddQueries();
        
        return services;
    }
}