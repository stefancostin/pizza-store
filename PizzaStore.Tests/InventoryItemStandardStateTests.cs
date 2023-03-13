using FluentAssertions;
using PizzaStore.Domain.Infrastructure;
using PizzaStore.Domain.Warehousing;

namespace PizzaStore.Tests;

public class InventoryItemStandardStateTests
{
    private readonly InventoryItem _inventoryItem;
    private readonly List<Event> _previousEvents;

    // Called before each test
    public InventoryItemStandardStateTests()
    {
        _previousEvents = new List<Event>();
        _inventoryItem = new InventoryItem();
    }

    [Fact]
    public void GivenPositiveQuantity_WhenAddInventoryItem_ThenItemQuantityIsAdded()
    {
        Given(InventoryItemIsCreated());

        When(AddItemQuantityToInventory(10));

        Then(() => _inventoryItem.Quantity.Should().Be(10));
    }

    private void Given(params Event[] previousEvents)
    {
        _previousEvents.Clear();
        _previousEvents.AddRange(previousEvents);
    }

    private void When(Command command)
    {
        foreach (var previousEvent in _previousEvents)
        {
            _inventoryItem.Apply(previousEvent);
        }

        var resultingEvents = _inventoryItem.Handle(command);

        foreach (var resultingEvent in resultingEvents)
        {
            _inventoryItem.Apply(resultingEvent);
        }
    }

    private void Then(Action executeAssertions)
    {
        executeAssertions();
    }
}
