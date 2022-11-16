using PackIT.Application.Exceptions;
using PackIT.Domain.Repository;
using PackIT.Shared.Abstractions.Commands;

namespace PackIT.Application.Commands.Handlers;

internal sealed class RemovePackingItemHandler : ICommandHandler<RemovePackingItem>
{
    private readonly IPackingListRepository _repository;

    public RemovePackingItemHandler(IPackingListRepository repository)
        => _repository = repository;

    public async Task HandleAsync(RemovePackingItem command)
    {
        var (id, name) = command;
        
        var packingList = await _repository.GetAsync(id);

        if (packingList is null)
        {
            throw new PackingListNotFoundException(id);
        }

        packingList.RemoveItem(name);

        await _repository.UpdateAsync(packingList);
    }
}