using PackIT.Domain.Consts;
using PackIT.Domain.Entities;
using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Factories;

public class PackingListFactory : IPackingListFactory
{
    public PackingList Create(PackingListId id, PackingListName name, Localization localization)
    {
        throw new NotImplementedException();
    }

    public PackingList CreateWithDefaultItems(PackingListId id, PackingListName name, TravelDays days, Temperature temperature, Gender gender)
    {
        throw new NotImplementedException();
    }
}