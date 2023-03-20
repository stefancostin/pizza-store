using FluentAssertions;
using PizzaStore.Core.Warehousing.Inventory;
using PizzaStore.Tests.Infrastructure;

namespace PizzaStore.Tests.InventoryItems.StateTests;

public class WhenReceiveInventory : AggregateStateTests<InventoryItem>
{
    [Fact]
    public void ThenItemQuantityIsAddedToInventory()
    {
        Given(
            InventoryItemIsCreated());

        When(
            ReceiveInventory(10));

        Then(
            inventoryItem => inventoryItem.Quantity.Should().Be(10));
    }
}
