using PackIT.Domain.Entities;
using PackIT.Domain.Events;
using PackIT.Domain.Exceptions;
using PackIT.Domain.Factories;
using PackIT.Domain.Policies;
using PackIT.Domain.ValueObjects;
using Shouldly;

namespace PackIT.UnitTests.Domain;

public class PackingListTests
{
    [Fact]
    public void AddItem_Throws_PackingItemAlreadyExistsException_When_There_Is_Already_Item_With_The_Same_Name()
    {
        var packingList = GetPackingList();
        packingList.AddItem(new PackingItem("Item1", 1));

        var exception = Record.Exception(() => packingList.AddItem(new PackingItem("Item1", 1)));

        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<PackingItemAlreadyExistsException>();
    }

    [Fact]
    public void AddItem_Adds_PackingItemAdded_Domain_Event_On_Success()
    {
        var packingList = GetPackingList();

        var exception = Record.Exception(() => packingList.AddItem(new PackingItem("Item1", 1)));

        var @event = packingList.Events.FirstOrDefault() as PackingItemAdded;
        
        exception.ShouldBeNull();
        
        // Can be used any of these assertions for checking the added event
        packingList.Events.Count().ShouldBe(1);
        @event.ShouldNotBeNull();
        @event.ShouldBeOfType<PackingItemAdded>();
    }

    #region ARRANGE

    private readonly IPackingListFactory _factory;

    public PackingListTests()
    {
        _factory = new PackingListFactory(Enumerable.Empty<IPackingItemsPolicy>());
    }

    private PackingList GetPackingList()
    {
        var packingList = _factory.Create(Guid.NewGuid(), "TestList", Localization.Create("Warsaw,Poland"));
        packingList.ClearEvents();

        return packingList;
    }

    #endregion
}