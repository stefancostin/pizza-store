using PizzaStore.Core.Abstractions;

namespace PizzaStore.Core.Sales.Pizzas;

public class Pizza : Aggregate
{
    public Guid PizzaId { get; private set; }
    public Guid RecipeId { get; private set; }
    public string Name { get; private set; }
    public int Price { get; private set; }

    public override void Apply(Event @event)
    {
        switch (@event)
        {
            case PizzaCreated pizzaCreated:
                ApplyEvent(pizzaCreated);
                return;
            default:
                throw new NotImplementedException("Event type not implemented");
        }
    }

    public override IEnumerable<Event> Handle(Command command)
    {
        switch (command)
        {
            case CreatePizza createPizza:
                return HandleCommand(createPizza);
            default:
                throw new NotImplementedException("Command type not implemented");
        }
    }

    private void ApplyEvent(PizzaCreated pizzaCreated)
    {
        PizzaId = pizzaCreated.PizzaId;
        RecipeId = pizzaCreated.RecipeId;
        Name = pizzaCreated.Name;
        Price = pizzaCreated.Price;
    }

    private IEnumerable<Event> HandleCommand(CreatePizza createPizza)
    {
        yield return new PizzaCreated(createPizza.PizzaId, createPizza.RecipeId, createPizza.Name, createPizza.Price);
    }
}
