using Microsoft.Extensions.DependencyInjection;
using PizzaStore.Core.Abstractions;
using PizzaStore.Core.Sales.Orders;

namespace PizzaStore.Core.Infrastructure.Data.Projections;

public class OrdersProjection : IProjection
{
    private readonly IServiceProvider _services;

    public OrdersProjection(IServiceProvider services)
    {
        _services = services;
    }

    public bool ShouldProcess(Event @event) =>
        @event is OrderCreated || @event is OrderPlaced;

    public void Dispatch(Event @event)
    {
        if (@event.AggregateId == Guid.Empty)
        {
            return;
        }

        using var readDbContext = _services.CreateScope().ServiceProvider.GetService<ReadContext>();

        if (@event is OrderCreated orderCreated)
        {
            var order = CreateOrder(orderCreated);
            readDbContext.Orders.Add(order);
        } 
        else if (@event is OrderPlaced orderPlaced)
        {
            var order = readDbContext.Orders.Find(orderPlaced.OrderId);
            order.IsPlaced = true;
        }

        readDbContext.SaveChanges();
    }

    private Order CreateOrder(OrderCreated orderCreated)
    {
        var order = new Order()
        {
            OrderId = orderCreated.OrderId
        };

        //order.OrderItems = orderCreated.Pizzas.Select(CreateOrderLine).ToList();
        //order.Total = orderCreated.Pizzas.Sum(p => p.Price);

        return order;
    }

    private OrderItem CreateOrderLine(Pizza pizza)
    {
        return new OrderItem()
        {
            OrderItemId = Guid.NewGuid(),
            PizzaId = pizza.PizzaId,

            // The price of the Pizza (product) can change anytime in the future,
            // however we want the price of the order line to stay the same.
            Price = pizza.Price 
        };
    }
}
