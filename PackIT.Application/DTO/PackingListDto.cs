using PackIT.Domain.ValueObjects;

namespace PackIT.Application.DTO;

public record PackingListDto(Guid Id, string Name, LocalizationDto Localization, IEnumerable<PackingItemDto> Items);