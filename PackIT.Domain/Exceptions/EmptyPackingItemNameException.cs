using PackIT.Shared.Abstractions.Exceptions;

namespace PackIT.Domain.Exceptions;

public class EmptyPackingItemNameException : PackItException
{
    public EmptyPackingItemNameException() : base("packing item name cannot be empty.")
    {
    }
}