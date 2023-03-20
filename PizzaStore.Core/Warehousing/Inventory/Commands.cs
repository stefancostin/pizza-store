using PizzaStore.Core.Abstractions;

namespace PizzaStore.Core.Warehousing.Inventory;

public record struct CreateInventoryItem(Guid InventoryItemId, string Name) : Command
{
    public Guid AggregateId => InventoryItemId;
}

public record struct ReceiveInventory(Guid InventoryItemId, int Quantity) : Command
{
    public Guid AggregateId => InventoryItemId;
}

public record struct ConsumeInventory(Guid InventoryItemId, int Quantity) : Command
{
    public Guid AggregateId => InventoryItemId;
}

public record struct AdjustInventory(Guid InventoryItemId, int Quantity) : Command
{
    public Guid AggregateId => InventoryItemId;
}
