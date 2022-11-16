using PackIT.Application.Exceptions;
using PackIT.Domain.Repository;
using PackIT.Domain.ValueObjects;
using PackIT.Shared.Abstractions.Commands;

namespace PackIT.Application.Commands.Handlers;

internal sealed class AddPackingItemHandler : ICommandHandler<AddPackingItem>
{
    private readonly IPackingListRepository _repository;

    public AddPackingItemHandler(IPackingListRepository repository)
        => _repository = repository;

    public async Task HandleAsync(AddPackingItem command)
    {
        var (id, name, quantity) = command;
        
        var packingList = await _repository.GetAsync(id);

        if (packingList is null)
        {
            throw new PackingListNotFoundException(id);
        }

        var packingItem = new PackingItem(name, quantity);
        packingList.AddItem(packingItem);

        await _repository.UpdateAsync(packingList);
    }
}