using PackIT.Application.DTO.External;
using PackIT.Domain.ValueObjects;

namespace PackIT.Application.Services;

// TODO: this service should call external API, but i'll hardcode it for testing purposes, whatever
public interface IWeatherService
{
    Task<WeatherDto> GetWeatherAsync(Localization localization);
}