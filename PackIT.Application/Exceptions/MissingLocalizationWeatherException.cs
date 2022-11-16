using PackIT.Domain.ValueObjects;
using PackIT.Shared.Abstractions.Exceptions;

namespace PackIT.Application.Exceptions;

public class MissingLocalizationWeatherException : PackItException
{
    public Localization Localization { get; }

    public MissingLocalizationWeatherException(Localization localization) : base($"couldn't fetch data from localization '{localization.Country} - {localization.City}'")
    {
        Localization = localization;
    }
}