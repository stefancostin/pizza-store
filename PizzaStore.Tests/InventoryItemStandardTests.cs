using FluentAssertions;
using PizzaStore.Domain;
using PizzaStore.Domain.Infrastructure;
using PizzaStore.Domain.Warehousing;

namespace PizzaStore.Tests;

public class InventoryItemStandardTests
{
    private readonly List<Event> _previousEvents;
    private readonly List<Event> _newEvents;

    private readonly CommandRouter _router;


    // Called before each test
    public InventoryItemStandardTests()
    {
        _previousEvents = new List<Event>();
        _newEvents = new List<Event>();

        _router = new CommandRouter(_ => _previousEvents, msg => _newEvents.Add(msg.Event));
    }

    [Fact]
    public void CreateInventoryItem_GivenGuidAndName_ItemIsCreated()
    {
        // Arrange
        var createInventoryItem = new CreateInventoryItem(FakeItem.Id, FakeItem.Name);
        var inventoryItemCreated = new InventoryItemCreated(FakeItem.Id, FakeItem.Name);

        // Act
        _router.HandleCommand(createInventoryItem);

        // Assert
        _newEvents.ToArray().Should().Equal(new Event[] { inventoryItemCreated });
    }

    [Fact]
    public void AddInventoryItem_GivenPositiveQuantity_ItemQuantityIsAdded()
    {
        // Arrange
        var inventoryItemCreated = new InventoryItemCreated(FakeItem.Id, FakeItem.Name);
        _previousEvents.Add(inventoryItemCreated);

        var itemQuantity = 10;
        var addItemToInventory = new AddItemQuantity(FakeItem.Id, itemQuantity);

        var itemAddedToInventory = new ItemQuantityAdded(FakeItem.Id, itemQuantity);

        // Act
        _router.HandleCommand(addItemToInventory);

        // Assert
        _newEvents.ToArray().Should().Equal(new Event[] { itemAddedToInventory });
    }
}

public static class FakeItem
{
    public static readonly Guid Id = Guid.NewGuid();
    public static readonly string Name = "Flour";
}
