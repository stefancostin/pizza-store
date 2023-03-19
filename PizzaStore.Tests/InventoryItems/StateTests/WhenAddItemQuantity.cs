using FluentAssertions;
using PizzaStore.Core.Inventory;
using PizzaStore.Tests.Infrastructure;

namespace PizzaStore.Tests.InventoryItems.StateTests;

public class WhenAddItemQuantity : AggregateStateTests<InventoryItem>
{
    [Fact]
    public void ThenItemQuantityIsAddedToInventory()
    {
        Given(
            InventoryItemIsCreated());

        When(
            AddItemQuantityToInventory(10));

        Then(
            inventoryItem => inventoryItem.Quantity.Should().Be(10));
    }
}
