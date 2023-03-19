using PizzaStore.API.JsonConverters;
using PizzaStore.Core.EventStores;
using PizzaStore.Core;
using PizzaStore.Core.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<EventContext>(builder => builder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=ReadStorage;Integrated Security=SSPI"));

builder.Services.AddScoped<IEventStore, SqlEventStore>();
builder.Services.AddScoped<CommandRouter>();

builder.Services.AddControllers()
    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.Converters.Add(new CommandConverter());
        opt.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
