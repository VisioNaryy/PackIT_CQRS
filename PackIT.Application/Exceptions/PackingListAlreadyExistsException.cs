using PackIT.Shared.Abstractions.Exceptions;

namespace PackIT.Application.Exceptions;

public class PackingListAlreadyExistsException : PackItException
{
    public string Name { get; }

    public PackingListAlreadyExistsException(string name) : base($"packing list with name {name} already exists.")
    {
        Name = name;
    }
}