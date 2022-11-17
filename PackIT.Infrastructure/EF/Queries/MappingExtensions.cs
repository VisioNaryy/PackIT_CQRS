using PackIT.Application.DTO;
using PackIT.Infrastructure.EF.Models;

namespace PackIT.Infrastructure.EF.Queries;

internal static class MappingExtensions
{
    public static PackingListDto AsDto(this PackingListReadModel readModel)
        => new
            (readModel.Id, 
            readModel.Name, 
            new LocalizationDto(readModel.Localization?.City, readModel.Localization?.Country), 
            readModel.Items?.Select(pi => 
                new PackingItemDto(pi.Name, pi.Quantity, pi.IsPacked))
            );
}