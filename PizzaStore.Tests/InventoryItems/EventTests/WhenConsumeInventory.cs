using PizzaStore.Tests.Infrastructure;

namespace PizzaStore.Tests.InventoryItems.EventTests;

public class WhenConsumeInventory : EventPipelineTests
{
    [Fact]
    public void AndSufficientStockThenItemQuantityIsRemoved()
    {
        Given(
            InventoryItemIsCreated(),
            ReceivedInInventory(10));

        When(
            ConsumeInventory(10));

        Then(
            ConsumedFromInventory(10));
    }

    [Fact]
    public void AndInsufficientStockThenItemQuantityIsNotRemoved()
    {
        Given(
            InventoryItemIsCreated());

        When(
            ConsumeInventory(10));

        Then(
            InsuffucientInventory());
    }
}
