using PizzaStore.Domain.CommandHandlers;
using PizzaStore.Domain.EventStores;
using PizzaStore.Domain.Infrastructure;
using PizzaStore.Domain.Warehousing;

internal class InventoryItemQuantitySetter : CommandHandler<SetItemQuantity, InventoryItem>
{
    public InventoryItemQuantitySetter(IEventStore eventStore) : base(eventStore)
    {
    }

    public override void Handle(SetItemQuantity command)
    {
        base.Handle(command);

        var removedEvents = _eventStore.Remove(command.AggregateId, IsStockOperation);

        // Removed events can now be archived somehwere else:
        // - a file system if we don't need to access this data besides the on-demand audit.
        // - another type of database that will help us access data in read - only mode (e.g.Elastic Search with its full - text search indexing capabilities).
        // - a separate event stream if we want to have direct access within the same event store. Then we can still use them as regular events in projections and subscriptions, making the operations part easier.
    }

    private bool IsStockOperation(Event e) => e is ItemQuantityAdded || e is ItemQuantityRemoved;
}
