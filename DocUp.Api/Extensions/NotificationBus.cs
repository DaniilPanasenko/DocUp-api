using System;
using System.Threading;
using System.Threading.Tasks;
using DocUp.Bll;
using DocUp.Bll.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DocUp.Api.Extensions
{
    public class ReadingsHostedService : IHostedService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private Timer _timer;


        public ReadingsHostedService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var period = TimeSpan.FromMinutes(1);
            _timer = new Timer(MakeTransactions, _scopeFactory, TimeSpan.FromMinutes(1), period);
            return Task.CompletedTask;
        }

        private void MakeTransactions(object state)
        {
            var factory = (IServiceScopeFactory)state;
            using var scope = factory.CreateScope();
            var handler = scope.ServiceProvider.GetRequiredService<ReadingsHandler>();
            handler.MakeScoreTransactionAsync().GetAwaiter().GetResult();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Dispose();
            return Task.CompletedTask;
        }
    }
}
