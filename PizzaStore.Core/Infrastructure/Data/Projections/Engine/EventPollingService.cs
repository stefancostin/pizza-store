using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PizzaStore.Core.Infrastructure.Data;

namespace PizzaStore.Core.Infrastructure.Data.Projections.Engine;

public class EventPollingService : BackgroundService
{
    private const int PollingRate = 1000; // milliseconds

    private readonly IServiceProvider _serviceProvider;
    private readonly EventProjectionRouter _router;

    public EventPollingService(IServiceProvider serviceProvider, EventProjectionRouter router)
    {
        _serviceProvider = serviceProvider;
        _router = router;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // This value should be persisted for checkpoints.
        var lastEventId = 0;

        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _serviceProvider.CreateScope();
            await using var context = scope.ServiceProvider.GetService<EventContext>();

            var newEvents = context.Events
                .Where(e => e.Id > lastEventId)
                .OrderBy(e => e.Id);

            foreach (var persistedEvent in newEvents)
            {
                _router.Dispatch(persistedEvent.Event);
                lastEventId = persistedEvent.Id;
            }

            await Task.Delay(PollingRate);
        }
    }
}
