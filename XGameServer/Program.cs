// See https://aka.ms/new-console-template for more information
using GameServer;
using GameServer.Networking;
using XGameServer;

using Microsoft.Extensions.Configuration;

// Build a config object, using env vars and JSON providers.
IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", true)
    .AddEnvironmentVariables()
    .Build();


Console.Title = $"Mir3D - Game Server - v0.0.0-dev";

Config.GameDataPath = config.GetValue<string>(nameof(Config.GameDataPath), "./Database");
Config.BackupFolder = config.GetValue<string>(nameof(Config.BackupFolder), "./Backups");
Config.GSPort = config.GetValue<ushort>(nameof(Config.GSPort), 8701);
Config.TSPort = config.GetValue<ushort>(nameof(Config.TSPort), 6678);
Config.PacketLimit = config.GetValue<ushort>(nameof(Config.PacketLimit), 100);
Config.AbnormalBlockTime = config.GetValue<ushort>(nameof(Config.AbnormalBlockTime), 5);
Config.DisconnectTime = config.GetValue<ushort>(nameof(Config.DisconnectTime), 5);
Config.MaxLevel = config.GetValue<byte>(nameof(Config.MaxLevel), 60);
Config.NoobLevel = config.GetValue<byte>(nameof(Config.NoobLevel), 0);
Config.EquipRepairDto = config.GetValue<decimal>(nameof(Config.EquipRepairDto), 1);
Config.ExtraDropRate = config.GetValue<decimal>(nameof(Config.ExtraDropRate), 0);
Config.ExpRate = config.GetValue<decimal>(nameof(Config.ExpRate), 1);
ComputingClass.LessExpGradeLevel = Config.LessExpGrade = config.GetValue<ushort>(nameof(Config.LessExpGrade), 10);
ComputingClass.LessExpGradeRate = Config.LessExpGradeRate = config.GetValue<decimal>(nameof(Config.LessExpGradeRate), 0.1M);
Config.TemptationTime = config.GetValue<ushort>(nameof(Config.TemptationTime), 120);
Config.ItemOwnershipTime = config.GetValue<ushort>(nameof(Config.ItemOwnershipTime), 3);
Config.ItemCleaningTime = config.GetValue<ushort>(nameof(Config.ItemCleaningTime), 5);

SEnvir.Logger = new ConsoleLogger();
GamePacket.Config(typeof(SConnection));

await SEnvir.Start();

while (true)
{
    var input = Console.ReadLine();
    if (string.IsNullOrEmpty(input)) continue;
    if (input[0] == '@') ProcessGMCommand(input);
}

void ProcessGMCommand(string command)
{
    SEnvir.AddCommandLog("=> " + command);
    GMCommand gmCommand;
    if (command[0] != '@')
    {
        SEnvir.AddCommandLog("<= Command error, GM commands must start with '@' at the start. '@View' to see all available commands");
    }
    else if (command.Trim('@', ' ').Length == 0)
    {
        SEnvir.AddCommandLog("<= Command error, GM commands can not be empty. Type '@View' to see all available commands");
    }
    else if (GMCommand.解析命令(command, out gmCommand))
    {
        if (gmCommand.ExecutionWay == ExecutionWay.前台立即执行)
        {
            gmCommand.Execute();
        }
        else if (gmCommand.ExecutionWay == ExecutionWay.优先后台执行)
        {
            if (MainProcess.Running)
            {
                MainProcess.CommandsQueue.Enqueue(gmCommand);
            }
            else
            {
                gmCommand.Execute();
            }
        }
        else if (gmCommand.ExecutionWay == ExecutionWay.只能后台执行)
        {
            if (MainProcess.Running)
            {
                MainProcess.CommandsQueue.Enqueue(gmCommand);
            }
            else
            {
                SEnvir.AddCommandLog("<= Command execution failed, the current command can only be executed when the server is running, please start the server first");
            }
        }
        else if (gmCommand.ExecutionWay == ExecutionWay.只能空闲执行)
        {
            if (!MainProcess.Running && (MainProcess.MainThread == null || !MainProcess.MainThread.IsAlive))
            {
                gmCommand.Execute();
            }
            else
            {
                SEnvir.AddCommandLog("<= Command execution failed, the current command can only be executed when the server is not running, please shut down the server first");
            }
        }
    }
}