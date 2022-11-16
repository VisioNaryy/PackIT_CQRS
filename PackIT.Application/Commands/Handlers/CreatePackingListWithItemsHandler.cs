using PackIT.Application.Exceptions;
using PackIT.Application.Services;
using PackIT.Domain.Exceptions;
using PackIT.Domain.Factories;
using PackIT.Domain.Repository;
using PackIT.Domain.ValueObjects;
using PackIT.Shared.Abstractions.Commands;

namespace PackIT.Application.Commands.Handlers;

public class CreatePackingListWithItemsHandler : ICommandHandler<CreatePackingListWithItems>
{
    private readonly IPackingListRepository _repository;
    private readonly IPackingListFactory _factory;
    private readonly IPackingListReadService _packingListReadService;
    private readonly IWeatherService _weatherService;

    public CreatePackingListWithItemsHandler(IPackingListRepository repository, IPackingListFactory factory, IPackingListReadService packingListReadService, IWeatherService weatherService)
    {
        _repository = repository;
        _factory = factory;
        _packingListReadService = packingListReadService;
        _weatherService = weatherService;
    }
    public async Task HandleAsync(CreatePackingListWithItems command)
    {
        var(id, name, days, gender, localizationWriteModel) = command;
        
        if (await _packingListReadService.ExistsByNameAsync(name))
        {
            throw new PackingListAlreadyExistsException(name);
        }

        var localization = new Localization(localizationWriteModel.City, localizationWriteModel.Country);
        var weather = await _weatherService.GetWeatherAsync(localization);

        if (weather is null)
        {
            throw new MissingLocalizationWeatherException(localization);
        }

        var packingList = _factory.CreateWithDefaultItems(id, name, days, weather.Temperature, gender, localization);

        await _repository.AddAsync(packingList);
    }
}