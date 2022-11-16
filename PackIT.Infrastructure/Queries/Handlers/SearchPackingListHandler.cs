using PackIT.Application.DTO;
using PackIT.Shared.Abstractions.Queries;

namespace PackIT.Infrastructure.Queries.Handlers;

public class SearchPackingListHandler : IQueryHandler<SearchPackingLists, IEnumerable<PackingItemDto>>
{

    
    public Task<IEnumerable<PackingItemDto>> HandleAsync(SearchPackingLists query)
    {
        throw new NotImplementedException();
    }
}