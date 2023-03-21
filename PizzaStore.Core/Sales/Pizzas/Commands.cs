using PizzaStore.Core.Abstractions;

namespace PizzaStore.Core.Sales.Pizzas;

public record struct CreatePizza(Guid PizzaId, Guid RecipeId, string Name, int Price) : Command
{
    public Guid AggregateId => PizzaId;
}
