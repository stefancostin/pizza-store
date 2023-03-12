using PizzaStore.Domain.CommandHandlers;
using PizzaStore.Domain.Infrastructure;
using PizzaStore.Domain.Warehousing;

internal class InventoryItemQuantitySetter : CommandHandler<SetItemQuantity, InventoryItem>
{
    public InventoryItemQuantitySetter(
        Func<Guid, IEnumerable<Event>> eventStream, Action<EventMessage> publishEvent) 
        : base(eventStream, publishEvent)
    {
    }

    public override void Handle(SetItemQuantity command)
    {
        base.Handle(command);

        _eventStream(command.AggregateId)
            .ToList().RemoveAll(e => e is ItemQuantityAdded || e is ItemQuantityRemoved);

        var x = _eventStream(command.AggregateId);
        var y = x.ToList().RemoveAll(e => e is ItemQuantityAdded || e is ItemQuantityRemoved);

        var bk = "str";
    }
}
