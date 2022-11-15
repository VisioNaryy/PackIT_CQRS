using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies.Gender;

internal sealed class MaleGenderPolicy : IPackingItemsPolicy
{
    public bool IsApplicable(PolicyData policyData) => policyData.Gender is Consts.Gender.Male;


    public IEnumerable<PackingItem> GenerateItems(PolicyData policyData)
        => new List<PackingItem>()
        {
            new("Laptop", 1),
            new("Beer", 10),
            new("Book", (uint)Math.Ceiling(policyData.Days / 7m))
        };
}