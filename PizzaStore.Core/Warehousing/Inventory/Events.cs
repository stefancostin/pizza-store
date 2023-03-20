using PizzaStore.Core.Abstractions;

namespace PizzaStore.Core.Warehousing.Inventory;

public record struct InventoryItemCreated(Guid ItemId, string Name) : Event
{
    public Guid AggregateId => ItemId;
}

public record struct InventoryReceived(Guid ItemId, int Quantity) : Event
{
    public Guid AggregateId => ItemId;
}

public record struct InventoryConsumed(Guid ItemId, int Quantity) : Event
{
    public Guid AggregateId => ItemId;
}

public record struct InventoryAdjusted(Guid ItemId, int Quantity) : Event
{
    public Guid AggregateId => ItemId;
}

public record struct InsufficientInventory(Guid ItemId) : Event
{
    public Guid AggregateId => ItemId;
}
