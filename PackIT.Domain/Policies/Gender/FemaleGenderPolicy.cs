using PackIT.Domain.Factories;
using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies.Gender;

internal sealed class FemaleGenderPolicy : IPackingItemsPolicy
{
    public bool IsApplicable(PolicyData policyData)
        => policyData.Gender is Consts.Gender.Female;

    public IEnumerable<PackingItem> GenerateItems(PolicyData policyData)
        => new List<PackingItem>
        {
            new("Lipstick", 1),
            new("Powder", 1),
            new("Eyeliner", 1)
        };
}