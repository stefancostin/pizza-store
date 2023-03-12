using FluentAssertions;
using PizzaStore.Domain.Warehousing;
using PizzaStore.Tests.Infrastructure;

namespace PizzaStore.Tests.InventoryItems.StateTests;

public class WhenSetItemQuantity : AggregateStateTests<InventoryItem>
{
    [Fact]
    public void ThenItemQuantityIsSet()
    {
        Given(
            InventoryItemIsCreated(),
            ItemQuantityIsAddedToInventory(10));

        When(
            SetItemQuantity(5));

        Then(
            inventoryItem => inventoryItem.Quantity.Should().Be(5));
    }
}
