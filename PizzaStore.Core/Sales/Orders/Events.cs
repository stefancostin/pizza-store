using PizzaStore.Core.Abstractions;
using PizzaStore.Core.Sales.Pizzas;

namespace PizzaStore.Core.Sales.Orders;

public record struct OrderCreated(Guid OrderId, IEnumerable<Pizza> Pizzas) : Event
{
    public Guid AggregateId => OrderId;
}

public record struct OrderPlaced(Guid OrderId) : Event
{
    public Guid AggregateId => OrderId;
}
