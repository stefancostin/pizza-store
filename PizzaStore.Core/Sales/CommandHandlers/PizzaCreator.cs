using PizzaStore.Core.Infrastructure;
using PizzaStore.Core.Infrastructure.EventStores;
using PizzaStore.Core.Sales.Pizzas;

namespace PizzaStore.Core.Sales.CommandHandlers;

internal class PizzaCreator : CommandHandler<CreatePizza, Pizza>
{
    public PizzaCreator(IEventStore eventStore) : base(eventStore)
    {
    }
}
