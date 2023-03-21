using PizzaStore.Core.Infrastructure;
using PizzaStore.Core.Infrastructure.EventStores;
using PizzaStore.Core.Sales.Orders;

namespace PizzaStore.Core.Sales.CommandHandlers
{
    internal class OrderSender : CommandHandler<PlaceOrder, Order>
    {
        public OrderSender(IEventStore eventStore) : base(eventStore)
        {
        }
    }
}
