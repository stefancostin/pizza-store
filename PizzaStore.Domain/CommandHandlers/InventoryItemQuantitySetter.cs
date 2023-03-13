using PizzaStore.Domain.CommandHandlers;
using PizzaStore.Domain.Stores;
using PizzaStore.Domain.Warehousing;

internal class InventoryItemQuantitySetter : CommandHandler<SetItemQuantity, InventoryItem>
{
    public InventoryItemQuantitySetter(IEventStore eventStore) : base(eventStore)
    {
    }

    public override void Handle(SetItemQuantity command)
    {
        base.Handle(command);

        _eventStore.Archive(command.AggregateId, e => e is ItemQuantityAdded || e is ItemQuantityRemoved);
    }
}
