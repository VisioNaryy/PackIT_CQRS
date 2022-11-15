using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies.Temperature;

internal sealed class LowTemperaturePolicy : IPackingItemsPolicy
{
    public bool IsApplicable(PolicyData policyData)
        => policyData.Temperature < 10D;

    public IEnumerable<PackingItem> GenerateItems(PolicyData policyData)
        => new List<PackingItem>
        {
            new("Winter hat", 1),
            new("Scarf", 1),
            new("Gloves", 1),
            new("Hoodie", 1),
            new("Warm jacket", 1),
        };
}