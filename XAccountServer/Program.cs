
using Microsoft.Extensions.Configuration;
using XAccountServer;

// Build a config object, using env vars and JSON providers.
IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", false)
    .AddEnvironmentVariables()
    .Build();


Console.Title = $"Mir3D - Login Server - v0.0.0-dev";

Config.LoginServerPort = config.GetValue<ushort>(nameof(Config.LoginServerPort), 6678);
Config.LoginGatePort = config.GetValue<ushort>(nameof(Config.LoginGatePort), 8001);
Config.Servers = config.GetSection(nameof(Config.Servers))?.Get<ServerConfig[]>() ?? Array.Empty<ServerConfig>();
if (!Config.Servers.Any()) Config.Servers = new ServerConfig[] { new ServerConfig { Name = "LomCN", PrivateIP = "127.0.0.1", PublicIP = "127.0.0.1", Port = 8701 } };

Config.DataDirectory = config.GetValue<string>(nameof(Config.DataDirectory), "./Accounts");

SEnvir.Start();

while (true)
{
    var message = Console.ReadLine();

    if (message == "exit")
        Environment.Exit(Environment.ExitCode);
}