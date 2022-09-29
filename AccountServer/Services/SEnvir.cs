using AccountServer.Properties;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountServer.Services
{
    public class SEnvir
    {
        private readonly Network _network;
        private readonly IAppConfiguration _settings;
        private readonly ILogger<SEnvir> _logger;

        public SEnvir(
            Network network,
            IAppConfiguration settings,
            ILogger<SEnvir> logger
        )
        {
            _network = network ?? throw new ArgumentNullException(nameof(network));
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
            _logger = logger;
        }

        public async Task Start()
        {
            if (_settings.Servers?.Count == 0)
            {
                _logger?.LogCritical("Server Configuration is empty. Start Failed.");
                return;
            }

            if (await _network.Start())
            {
                _logger.LogInformation($"Server started!");
            }
            else
            {
                _logger.LogCritical($"An error ocurred starting server");
            }
        }

        public async Task Stop()
        {
            await _network.Stop();
        }
    }
}
