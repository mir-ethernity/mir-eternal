using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountServer.Services.Default
{
    public class FormLogger : ILogger
    {
        private readonly MainForm _form;
        private string _name;

        public FormLogger(MainForm form, string name)
        {
            _form = form ?? throw new ArgumentNullException(nameof(form));
            _name = name;
        }

        public IDisposable BeginScope<TState>(TState state) => default!;

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel)) return;

            _form.LogInTextBox.AppendText($"[{logLevel}][{_name}] - {DateTime.Now:HH:mm:ss} - {formatter(state, exception)}{Environment.NewLine}");
        }
    }
}
