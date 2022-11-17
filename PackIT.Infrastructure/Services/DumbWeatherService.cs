using PackIT.Application.DTO.External;
using PackIT.Application.Services;
using PackIT.Domain.ValueObjects;

namespace PackIT.Infrastructure.Services;

public class DumbWeatherService : IWeatherService
{
    public Task<WeatherDto> GetWeatherAsync(Localization localization)
    {
        var weather = new WeatherDto(new Random().Next(5, 30));

        return Task.FromResult(weather);
    }
}