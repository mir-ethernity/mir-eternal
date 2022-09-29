using AccountServer.Properties;
using AccountServer.Repositories;
using AccountServer.Services;
using AccountServer.Services.Default;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Configuration;
using System.Threading;
using System.Windows.Forms;

namespace AccountServer
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.SetCompatibleTextRenderingDefault(false);

            using IHost host = Host.CreateDefaultBuilder()
                 .ConfigureServices((context, services) =>
                 {
                     services
                         .AddLazyResolution()
                         .AddLogging(logging =>
                         {
                             var builder = logging
                                .AddConfiguration(context.Configuration);

                             builder.Services.AddSingleton<ILoggerProvider, FormLoggerProvider>();
                         })
                         .AddSingleton<IAccountService, AccountService>()
                         .AddSingleton<SEnvir>()
                         .AddSingleton<MainForm>()
                         .AddSingleton<IAppConfiguration, SettingsConfiguration>()
                         .AddSingleton<Network>();

                     switch (Settings.Default.DBType)
                     {
                         case "json":
                             services.AddSingleton<IAccountRepository, AccountJsonRepository>();
                             break;
                         default:
                             throw new NotImplementedException($"Not implemented DBType: {Settings.Default.DBType}");
                     }

                     services.AddHostedService<WinFormHostService>();
                 })
                .Build();

            host.Run();
        }

    }
}
