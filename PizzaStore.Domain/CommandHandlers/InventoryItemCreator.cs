﻿using PizzaStore.Domain.EventStores;
using PizzaStore.Domain.Warehousing;

namespace PizzaStore.Domain.CommandHandlers;

internal class InventoryItemCreator : CommandHandler<CreateInventoryItem, InventoryItem>
{
    public InventoryItemCreator(IEventStore eventStore) : base(eventStore)
    {
    }
}
