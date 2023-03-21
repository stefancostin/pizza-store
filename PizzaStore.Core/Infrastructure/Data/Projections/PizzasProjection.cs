using Microsoft.Extensions.DependencyInjection;
using PizzaStore.Core.Abstractions;
using PizzaStore.Core.Sales.Pizzas;

namespace PizzaStore.Core.Infrastructure.Data.Projections;

public class PizzasProjection : IProjection
{
    private readonly IServiceProvider _services;

    public PizzasProjection(IServiceProvider services)
    {
        _services = services;
    }

    public bool ShouldProcess(Event @event) => @event is PizzaCreated;

    public void Dispatch(Event @event)
    {
        if (@event.AggregateId == Guid.Empty)
        {
            return;
        }

        using var readDbContext = _services.CreateScope().ServiceProvider.GetService<ReadContext>();

        var pizza = CreatePizza((PizzaCreated)@event);

        readDbContext.Pizzas.Add(pizza);

        readDbContext.SaveChanges();
    }

    private Pizza CreatePizza(PizzaCreated @event)
    {
        return new Pizza()
        {
            PizzaId = @event.PizzaId,
            RecipeId = @event.RecipeId,
            Name = @event.Name,
            Price = @event.Price
        };
    }
}
