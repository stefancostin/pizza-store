using FluentAssertions;
using PizzaStore.Core.Warehousing.Inventory;
using PizzaStore.Tests.Infrastructure;

namespace PizzaStore.Tests.Warehousing.StateTests;

public class WhenConsumeInventory : AggregateStateTests<InventoryItem>
{
    [Fact]
    public void AndStockIsTheSameAsQuantityRemovedThenItemQuantityIsZero()
    {
        Given(
            InventoryItemIsCreated(),
            ReceivedInInventory(10));

        When(
            ConsumeInventory(10));

        Then(
            inventoryItem => inventoryItem.Quantity.Should().Be(0));
    }

    [Fact]
    public void AndStockIsGreaterThanQuantityRemovedThenItemQuantityIsPositive()
    {
        Given(
            InventoryItemIsCreated(),
            ReceivedInInventory(10));

        When(
            ConsumeInventory(5));

        Then(
            inventoryItem => inventoryItem.Quantity.Should().Be(5));
    }
}
