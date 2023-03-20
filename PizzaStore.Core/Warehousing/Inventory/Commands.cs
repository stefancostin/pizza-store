using PizzaStore.Core.Abstractions;

namespace PizzaStore.Core.Warehousing.Inventory;

public record struct CreateInventoryItem(Guid ItemId, string Name) : Command
{
    public Guid AggregateId => ItemId;
}

public record struct ReceiveInventory(Guid ItemId, int Quantity) : Command
{
    public Guid AggregateId => ItemId;
}

public record struct ConsumeInventory(Guid ItemId, int Quantity) : Command
{
    public Guid AggregateId => ItemId;
}

public record struct AdjustInventory(Guid ItemId, int Quantity) : Command
{
    public Guid AggregateId => ItemId;
}
