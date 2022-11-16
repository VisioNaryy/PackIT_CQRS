using PackIT.Application.DTO;
using PackIT.Shared.Abstractions.Queries;

namespace PackIT.Infrastructure.Queries;

public class SearchPackingLists : IQuery<IEnumerable<PackingItemDto>>
{
    public string SearchPhrase { get; set; }
}