using PackIT.Application.DTO;
using PackIT.Domain.Repository;
using PackIT.Shared.Abstractions.Queries;

namespace PackIT.Infrastructure.Queries.Handlers;

public class GetPackingListHandler : IQueryHandler<GetPackingList, PackingListDto>
{
    private readonly IPackingListRepository _repository;

    public GetPackingListHandler(IPackingListRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<PackingListDto> HandleAsync(GetPackingList query)
    {
        // var id = query.Id;
        //
        // var packingList = await _repository.GetAsync(id);
        //
        // return packingList;
        throw new NotImplementedException();
    }
}