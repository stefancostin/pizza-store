using PizzaStore.Core.Abstractions;

namespace PizzaStore.Core.Warehousing.Inventory;

public record struct InventoryItemCreated(Guid InventoryItemId, string Name) : Event
{
    public Guid AggregateId => InventoryItemId;
}

public record struct InventoryReceived(Guid InventoryItemId, int Quantity) : Event
{
    public Guid AggregateId => InventoryItemId;
}

public record struct InventoryConsumed(Guid InventoryItemId, int Quantity) : Event
{
    public Guid AggregateId => InventoryItemId;
}

public record struct InventoryAdjusted(Guid InventoryItemId, int Quantity) : Event
{
    public Guid AggregateId => InventoryItemId;
}

public record struct InsufficientInventory(Guid InventoryItemId) : Event
{
    public Guid AggregateId => InventoryItemId;
}
