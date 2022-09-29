using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;

namespace AccountServer.Services.Default
{
    public class FormLoggerProvider : ILoggerProvider
    {
        private readonly ConcurrentDictionary<string, FormLogger> _loggers = new(StringComparer.OrdinalIgnoreCase);
        private readonly IServiceProvider _services;

        public FormLoggerProvider(IServiceProvider services)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
        }

        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, name =>
            {
                return new FormLogger(_services.GetService<MainForm>(), name);
            });
        }

        public void Dispose()
        {
            _loggers.Clear();
        }
    }
}
