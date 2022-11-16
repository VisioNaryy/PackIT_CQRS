using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PackIT.Infrastructure.EF.Contexts;
using PackIT.Infrastructure.EF.Options;
using PackIT.Shared.Options;

namespace PackIT.Infrastructure.EF;

internal static class Extensions
{
    public static IServiceCollection AddSqlServerConnection(this IServiceCollection services, IConfiguration configuration)
    {
        var options = configuration.GetOptions<SqlServerOptions>("ConnectionStrings");

        services.AddDbContext<ReadDbContext>(x =>
        {
            x.UseSqlServer(options.DefaultConnection);
        });
        services.AddDbContext<WriteDbContext>(x =>
        {
            x.UseSqlServer(options.DefaultConnection);
        });
        
        return services;
    }
}