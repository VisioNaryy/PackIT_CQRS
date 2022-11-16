using PackIT.Application.Exceptions;
using PackIT.Domain.Repository;
using PackIT.Shared.Abstractions.Commands;

namespace PackIT.Application.Commands.Handlers;

internal sealed class RemovePackingListHandler : ICommandHandler<RemovePackingList>
{
    private readonly IPackingListRepository _repository;

    public RemovePackingListHandler(IPackingListRepository repository)
        => _repository = repository;

    public async Task HandleAsync(RemovePackingList command)
    {
        var id = command.Id;
        
        var packingList = await _repository.GetAsync(id);

        if (packingList is null)
        {
            throw new PackingListNotFoundException(id);
        }

        await _repository.DeleteAsync(packingList);
    }
}