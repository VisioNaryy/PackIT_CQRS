using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PackIT.Application.Services;
using PackIT.Domain.Repository;
using PackIT.Infrastructure.EF.Contexts;
using PackIT.Infrastructure.EF.Options;
using PackIT.Infrastructure.EF.Repositories;
using PackIT.Infrastructure.EF.Services;
using PackIT.Shared.Options;

namespace PackIT.Infrastructure.EF;

internal static class Extensions
{
    public static IServiceCollection AddSqlServerConnection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IPackingListRepository, SqlServerPackingListRepository>();
        services.AddScoped<IPackingListReadService, SqlServerPackingListReadService>();
        
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