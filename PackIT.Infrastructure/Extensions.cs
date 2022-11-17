using System.Windows.Input;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PackIT.Application.Services;
using PackIT.Domain.Repository;
using PackIT.Infrastructure.EF;
using PackIT.Infrastructure.EF.Repositories;
using PackIT.Infrastructure.EF.Services;
using PackIT.Infrastructure.Logging;
using PackIT.Infrastructure.Services;
using PackIT.Shared.Abstractions.Commands;
using PackIT.Shared.Queries;

namespace PackIT.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSqlServerConnection(configuration);
        services.AddQueries();
        
        services.AddSingleton<IWeatherService, DumbWeatherService>();

        services.TryDecorate(typeof(ICommandHandler<>), typeof(LoggingCommandHandlerDecorator<>));
        return services;
    }
}