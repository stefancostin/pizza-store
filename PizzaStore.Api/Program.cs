using Microsoft.EntityFrameworkCore;
using PizzaStore.Api.JsonConverters;
using PizzaStore.Core.Infrastructure;
using PizzaStore.Core.Infrastructure.Data;
using PizzaStore.Core.Infrastructure.Data.Projections;
using PizzaStore.Core.Infrastructure.Data.Projections.Engine;
using PizzaStore.Core.Infrastructure.EventStores;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<EventContext>(builder => builder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=EventStorage;Integrated Security=SSPI"));
builder.Services.AddDbContext<ReadContext>(builder => builder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=ReadStorage;Integrated Security=SSPI"));

builder.Services.AddHostedService<EventPollingService>();
builder.Services.AddSingleton<EventProjectionRouter>();

builder.Services.AddSingleton<IProjection, InventoryItemsProjection>();
builder.Services.AddSingleton<IProjection, InventoryProjection>();
//builder.Services.AddSingleton<IProjection, RecipesProjection>();
//builder.Services.AddSingleton<IProjection, PizzasProjection>();
//builder.Services.AddSingleton<IProjection, OrdersProjection>();

builder.Services.AddScoped<IEventStore, SqlEventStore>();
builder.Services.AddScoped<CommandRouter>();
builder.Services.AddScoped<EventRouter>();

builder.Services.AddControllers()
    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.Converters.Add(new CommandConverter());
        opt.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
