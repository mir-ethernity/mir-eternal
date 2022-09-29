using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountServer.Services
{
    public class WinFormHostService : IHostedService
    {
        private readonly IServiceProvider _services;

        public WinFormHostService(IServiceProvider services)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Application.Run(_services.GetService<MainForm>());

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Application.Exit();

            return Task.CompletedTask;
        }
    }
}
