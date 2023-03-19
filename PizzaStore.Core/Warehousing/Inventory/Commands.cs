using PizzaStore.Core.Abstractions;

namespace PizzaStore.Core.Warehousing.Inventory;

public record struct CreateInventoryItem(Guid InventoryItemId, string Name) : Command
{
    public Guid AggregateId => InventoryItemId;
}

public record struct AddItemQuantity(Guid InventoryItemId, int Quantity) : Command
{
    public Guid AggregateId => InventoryItemId;
}

public record struct RemoveItemQuantity(Guid InventoryItemId, int Quantity) : Command
{
    public Guid AggregateId => InventoryItemId;
}

public record struct SetItemQuantity(Guid InventoryItemId, int Quantity) : Command
{
    public Guid AggregateId => InventoryItemId;
}
