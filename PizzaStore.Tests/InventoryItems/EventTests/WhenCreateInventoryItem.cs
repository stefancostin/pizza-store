using PizzaStore.Tests.Infrastructure;

namespace PizzaStore.Tests;

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
