using CarProject.Core.Abstract.Service;
using CarProject.Core.Entities;
using EasyNetQ;
using Microsoft.Extensions.Hosting;

namespace CarProject.Infrastructure.Service
{
    public class VisitConsumerService : IHostedService
    {
        private readonly IBus _bus;
        private readonly IAdvertVisitService _advertVisitService;
        public VisitConsumerService(IBus bus, IAdvertVisitService advertVisitService)
        {
            _bus = bus;
            _advertVisitService = advertVisitService;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _bus.PubSub.SubscribeAsync<AdvertVisit>($"VisitConsumer", message => Task.Factory.StartNew(async () =>
            {
                await HandleMessage(message);
            }));
            Console.WriteLine($"Background task doing work.");
            return;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private async Task HandleMessage(AdvertVisit visit)
        {
            Console.WriteLine($"{visit.AdvertId} visited from: {visit.IPAdress}");
            await _advertVisitService.AddVisit(visit.AdvertId.ToString(), visit.IPAdress);

        }
    }
}
