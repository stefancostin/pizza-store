﻿using PizzaStore.Domain.Infrastructure;

namespace PizzaStore.Domain.Warehousing;

public record struct InventoryItemCreated(Guid InventoryItemId, string Name) : Event;

public record struct ItemQuantityAdded(Guid InventoryItemId, int Quantity) : Event;

public record struct ItemQuantityRemoved(Guid InventoryItemId, int Quantity) : Event;

public record struct InsufficientItemQuantity(Guid InventoryItemId) : Event;
 