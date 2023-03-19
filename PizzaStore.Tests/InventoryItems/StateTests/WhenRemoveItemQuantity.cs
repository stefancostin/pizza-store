using FluentAssertions;
using PizzaStore.Core.Inventory;
using PizzaStore.Tests.Infrastructure;

namespace PizzaStore.Tests.InventoryItems.StateTests;

public class WhenRemoveItemQuantity : AggregateStateTests<InventoryItem>
{
    [Fact]
    public void AndStockIsTheSameAsQuantityRemovedThenItemQuantityIsZero()
    {
        Given(
            InventoryItemIsCreated(),
            ItemQuantityIsAddedToInventory(10));

        When(
            RemoveItemQuantityFromInventory(10));

        Then(
            inventoryItem => inventoryItem.Quantity.Should().Be(0));
    }

    [Fact]
    public void AndStockIsGreaterThanQuantityRemovedThenItemQuantityIsPositive()
    {
        Given(
            InventoryItemIsCreated(),
            ItemQuantityIsAddedToInventory(10));

        When(
            RemoveItemQuantityFromInventory(5));

        Then(
            inventoryItem => inventoryItem.Quantity.Should().Be(5));
    }
}
