using PizzaStore.Core.Abstractions;
using PizzaStore.Core.Sales.Pizzas;

namespace PizzaStore.Core.Sales.Orders;

/// <summary>Aggregate Root</summary>
public class Order : Aggregate
{
    public Guid OrderId { get; private set; }
    public IEnumerable<Pizza> Pizzas { get; private set; }
    public int Total { get; private set; }
    public bool IsPlaced { get; private set; }

    public override void Apply(Event @event)
    {
        switch (@event)
        {
            case OrderCreated orderCreated:
                ApplyEvent(orderCreated);
                return;
            case OrderPlaced orderPlaced:
                ApplyEvent(orderPlaced);
                return;
            default:
                throw new NotImplementedException("Event type not implemented");
        }
    }

    public override IEnumerable<Event> Handle(Command command)
    {
        switch (command)
        {
            case CreateOrder createOrder:
                return HandleCommand(createOrder);
            case PlaceOrder placeOrder:
                return HandleCommand(placeOrder);
            default:
                throw new NotImplementedException("Command type not implemented");
        }
    }

    private void ApplyEvent(OrderCreated orderCreated)
    {
        OrderId = orderCreated.OrderId;
        Pizzas = orderCreated.Pizzas;
    }

    private void ApplyEvent(OrderPlaced _)
    {
        IsPlaced = true;
    }

    private IEnumerable<Event> HandleCommand(CreateOrder createOrder)
    {
        yield return new OrderCreated(createOrder.OrderId, createOrder.Pizzas);
    }

    private IEnumerable<Event> HandleCommand(PlaceOrder placeOrder)
    {
        yield return new OrderPlaced(placeOrder.OrderId);
    }
}
