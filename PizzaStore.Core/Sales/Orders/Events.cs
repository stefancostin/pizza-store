using PizzaStore.Core.Abstractions;

namespace PizzaStore.Core.Sales.Orders;

public record struct OrderCreated(Guid OrderId, ISet<Guid> Pizzas) : Event
{
    public Guid AggregateId => OrderId;
}

public record struct OrderPlaced(Guid OrderId) : Event
{
    public Guid AggregateId => OrderId;
}
