using PizzaStore.Core.Infrastructure;
using PizzaStore.Core.Infrastructure.EventStores;
using PizzaStore.Core.Sales.Orders;

namespace PizzaStore.Core.Sales.CommandHandlers;

internal class OrderCreator : CommandHandler<CreateOrder, Order>
{
    public OrderCreator(IEventStore eventStore) : base(eventStore)
    {
    }
}
