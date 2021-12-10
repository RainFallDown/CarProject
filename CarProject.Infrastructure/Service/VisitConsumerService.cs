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

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _bus.PubSub.Subscribe<AdvertVisit>($"VisitConsumer", HandleMessage);
            Console.WriteLine($"Background task doing work.");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private void HandleMessage(AdvertVisit visit)
        {
            Console.WriteLine($"{visit.AdvertId} visited from: {visit.IPAdress}");
            _advertVisitService.AddVisit(visit.AdvertId.ToString(), visit.IPAdress);

        }
    }
}
