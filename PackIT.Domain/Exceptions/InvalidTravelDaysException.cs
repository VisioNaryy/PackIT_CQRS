using PackIT.Shared.Abstractions.Exceptions;

namespace PackIT.Domain.Exceptions;

public class InvalidTravelDaysException : PackItException
{
    public ushort Days { get; }

    public InvalidTravelDaysException(ushort days) : base($"value '{days}' is invalid travel days.")
        => Days = days;
}