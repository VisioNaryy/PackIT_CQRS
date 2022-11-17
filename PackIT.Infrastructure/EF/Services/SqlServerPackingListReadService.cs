using Microsoft.EntityFrameworkCore;
using PackIT.Application.Services;
using PackIT.Infrastructure.EF.Contexts;
using PackIT.Infrastructure.EF.Models;

namespace PackIT.Infrastructure.EF.Services;

internal sealed class SqlServerPackingListReadService: IPackingListReadService
{
    private readonly DbSet<PackingListReadModel> _packingLists;

    public SqlServerPackingListReadService(ReadDbContext context)
    {
        _packingLists = context.PackingLists;
    }

    public Task<bool> ExistsByNameAsync(string name)
        => _packingLists.AnyAsync(pl => pl.Name == name);
}