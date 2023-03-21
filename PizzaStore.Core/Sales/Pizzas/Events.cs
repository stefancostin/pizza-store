using PizzaStore.Core.Abstractions;

namespace PizzaStore.Core.Sales.Pizzas;

public record struct PizzaCreated(Guid PizzaId, Guid RecipeId, string Name, int Price) : Event
{
    public Guid AggregateId => PizzaId;
}
