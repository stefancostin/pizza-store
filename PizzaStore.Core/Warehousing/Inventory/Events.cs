﻿using PizzaStore.Core.Abstractions;

namespace PizzaStore.Core.Warehousing.Inventory;

public record struct InventoryItemCreated(Guid InventoryItemId, string Name) : Event
{
    public Guid AggregateId => InventoryItemId;
}

public record struct ItemQuantityAdded(Guid InventoryItemId, int Quantity) : Event
{
    public Guid AggregateId => InventoryItemId;
}

public record struct ItemQuantityRemoved(Guid InventoryItemId, int Quantity) : Event
{
    public Guid AggregateId => InventoryItemId;
}

public record struct ItemQuantitySet(Guid InventoryItemId, int Quantity) : Event
{
    public Guid AggregateId => InventoryItemId;
}

public record struct InsufficientItemQuantity(Guid InventoryItemId) : Event
{
    public Guid AggregateId => InventoryItemId;
}