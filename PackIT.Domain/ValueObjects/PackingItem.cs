using PackIT.Domain.Exceptions;

namespace PackIT.Domain.ValueObjects;

public class PackingItem
{
    public string Name { get; set; }
    public uint Quantity { get; set; }
    public bool IsPacked { get; set; }

    public PackingItem(string name, uint quantity, bool isPacked)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new EmptyPackingItemNameException();
        
        Name = name;
        Quantity = quantity;
        IsPacked = isPacked;
    }
}