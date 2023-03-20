using FluentAssertions;
using PizzaStore.Core.Warehousing.Inventory;
using PizzaStore.Tests.Infrastructure;

namespace PizzaStore.Tests.InventoryItems.StateTests;

public class WhenCreateInventoryItem : AggregateStateTests<InventoryItem>
{
    [Fact]
    public void ThenInventoryItemIsCreated()
    {
        Given();

        When(
            CreateInventoryItem());

        Then(
            inventoryItem => inventoryItem.Name.Should().Be(ItemName));
    }
}
