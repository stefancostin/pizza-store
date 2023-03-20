using FluentAssertions;
using PizzaStore.Core.Warehousing.Inventory;
using PizzaStore.Tests.Infrastructure;

namespace PizzaStore.Tests.InventoryItems.StateTests;

public class WhenAdjustInventory : AggregateStateTests<InventoryItem>
{
    [Fact]
    public void ThenItemQuantityIsSet()
    {
        Given(
            InventoryItemIsCreated(),
            ReceivedInInventory(10));

        When(
            AdjustInventory(5));

        Then(
            inventoryItem => inventoryItem.Quantity.Should().Be(5));
    }
}
