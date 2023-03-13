using PizzaStore.Tests.Infrastructure;

namespace PizzaStore.Tests.InventoryItems.EventTests;

public class WhenCreateInventoryItem : EventPipelineTests
{
    [Fact]
    public void ThenInventoryItemIsCreated()
    {
        Given();

        When(
            CreateInventoryItem());

        Then(
            InventoryItemIsCreated());
    }
}
