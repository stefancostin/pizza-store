using PizzaStore.Core.Abstractions;
using PizzaStore.Core.Sales.Pizzas;

namespace PizzaStore.Core.Sales.Orders;

public record struct CreateOrder(Guid OrderId, ISet<Pizza> Pizzas) : Command
{
    public Guid AggregateId => OrderId;
}

public record struct PlaceOrder(Guid OrderId) : Command
{
    public Guid AggregateId => OrderId;
}
