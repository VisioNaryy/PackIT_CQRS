using PackIT.Application.Exceptions;
using PackIT.Domain.Repository;
using PackIT.Shared.Abstractions.Commands;

namespace PackIT.Application.Commands.Handlers;

internal sealed class PackItemHandler : ICommandHandler<PackItem>
{
    private readonly IPackingListRepository _repository;

    public PackItemHandler(IPackingListRepository repository)
        => _repository = repository;

    public async Task HandleAsync(PackItem command)
    {
        var (id, name) = command;
        
        var packingList = await _repository.GetAsync(id);

        if (packingList is null)
        {
            throw new PackingListNotFoundException(id);
        }
            
        packingList.PackItem(name);
            
        await _repository.UpdateAsync(packingList);
    }
}