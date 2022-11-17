using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PackIT.Application.Services;
using PackIT.Domain.Repository;
using PackIT.Infrastructure.EF;
using PackIT.Infrastructure.EF.Repositories;
using PackIT.Infrastructure.EF.Services;
using PackIT.Infrastructure.Services;
using PackIT.Shared.Queries;

namespace PackIT.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSqlServerConnection(configuration);
        services.AddQueries();
        
        services.AddSingleton<IWeatherService, DumbWeatherService>();
        
        return services;
    }
}