using PackIT.Domain.Exceptions;
using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Entities;

public class PackingList
{
    public Guid Id { get; private set; }

    private PackingListName _name;
    private Localization _localization;
    private readonly LinkedList<PackingItem> _items;

    internal PackingList(Guid id, string name, Localization localization, LinkedList<PackingItem> items)
    {
        Id = id;
        _name = name;
        _localization = localization;
        _items = items;
    }

    public void AddItem(PackingItem item)
    {
        var alreadyExists = _items.Any(x => x.Name == item.Name);

        //TODO: can be reconstructed to generate some response to client with exception message or putted to custom validator.
        if (alreadyExists)
            throw new PackingItemAlreadyExistsException(_name, item.Name);

        _items.AddLast(item);
    }
}