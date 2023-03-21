using PizzaStore.Core.Abstractions;

namespace PizzaStore.Core.Sales.Orders;

public record struct CreateOrder(Guid OrderId, ISet<Guid> Pizzas) : Command
{
    public Guid AggregateId => OrderId;
}

public record struct PlaceOrder(Guid OrderId) : Command
{
    public Guid AggregateId => OrderId;
}
