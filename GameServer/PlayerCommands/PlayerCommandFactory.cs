using GameServer.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GameServer.PlayerCommands
{
    public class PlayerCommandMethodInfo
    {
        public MethodInfo MethodInfo { get; set; }
        public Type CommandType { get; set; }
        public string CommandName => CommandType.Name.Replace("PlayerCommand", string.Empty);
    }

    public class PlayerCommandFieldInfo
    {
        public string Name => Info.Name;
        public FieldInfo Info { get; set; }
        public FieldAttribute Attribute { get; set; }
        public Type ValueType { get; set; }
        public bool IsOptional => Attribute.IsOptional;
    }
    public class PlayerCommandInfo
    {
        public string Name { get; set; }
        public Type CommandType { get; set; }
        public PlayerCommandFieldInfo[] Fields { get; set; }
        public MethodInfo ProcessMethod { get; set; }
        public int RequiredFields { get; set; }
    }


    public static class PlayerCommandFactory
    {
        private static readonly Regex _commandRegex = new Regex(@"^\@(?<cmd>.+?)(?:\s|$)(?<args>.+?)?$");
        private static readonly Regex _commandArgsRegex = new Regex(@"(?:\""(?<val_quoted>.+?)\""|\s*(?<val_noquote>.+?)(?:\s+|$))");
        public static readonly Dictionary<string, PlayerCommandInfo> PlayerCommandTypes = new Dictionary<string, PlayerCommandInfo>();

        static PlayerCommandFactory()
        {
            var playerCommandTypes = typeof(PlayerCommand).Assembly
                .GetExportedTypes()
                .Where(x => !x.IsAbstract && x.IsAssignableTo(typeof(PlayerCommand)))
                .ToArray();

            foreach (var command in playerCommandTypes)
            {
                var fields = command.GetFields()
                    .Where(x => x.CustomAttributes.Any(x => x.AttributeType == typeof(FieldAttribute)))
                    .Select(x => new PlayerCommandFieldInfo
                    {
                        Info = x,
                        Attribute = x.GetCustomAttribute<FieldAttribute>(),
                        ValueType = x.FieldType.IsGenericType && x.FieldType.GetGenericTypeDefinition() == typeof(Nullable<>)
                         ? x.FieldType.GetGenericArguments()[0]
                         : x.FieldType,
                    })
                    .OrderBy(x => x.Attribute.Position)
                    .ToArray();

                var name = command.Name.Replace("PlayerCommand", string.Empty).ToLowerInvariant();

                PlayerCommandTypes.Add(name, new PlayerCommandInfo
                {
                    Name = name,
                    CommandType = command,
                    Fields = fields,
                    RequiredFields = fields.Count(x => !x.IsOptional),
                    ProcessMethod = command.GetMethod(nameof(PlayerCommand.Execute))
                });
            }
        }

        public static bool TryExecute(PlayerObject player, string text)
        {
            text = text.TrimEnd('\0');

            var match = _commandRegex.Match(text);

            if (!match.Success)
                return false;

            var commandName = match.Groups["cmd"].Value.ToLowerInvariant();
            var commandArgs = match.Groups["args"].Value;

            if (!PlayerCommandTypes.ContainsKey(commandName))
                return false;

            var commandInfo = PlayerCommandTypes[commandName];

            var command = (PlayerCommand)Activator.CreateInstance(commandInfo.CommandType);
            command.Player = player;

            if (string.IsNullOrEmpty(commandArgs) && commandInfo.RequiredFields > 0)
            {
                player.SendMessage($"Invalid command parameters");
                return true;
            }

            if (!string.IsNullOrEmpty(commandArgs))
            {
                var matches = _commandArgsRegex.Matches(commandArgs);

                if (matches.Count > commandInfo.Fields.Length)
                {
                    player.SendMessage($"Invalid command parameters");
                    return true;
                }

                if (commandInfo.RequiredFields > matches.Count)
                {
                    player.SendMessage($"Invalid command parameters");
                    return true;
                }

                for (var i = 0; i < matches.Count; i++)
                {
                    try
                    {
                        var valueStr = !string.IsNullOrEmpty(matches[i].Groups["val_quoted"].Value)
                        ? matches[i].Groups["val_quoted"].Value
                        : matches[i].Groups["val_noquote"].Value;

                        var field = commandInfo.Fields[i];
                        var value = GMCommand.ParseValue[field.ValueType](valueStr);
                        field.Info.SetValue(command, value);
                    }
                    catch
                    {
                        player.SendMessage($"Invalid command parameters");
                        return true;
                    }
                }
            }

            commandInfo.ProcessMethod.Invoke(command, null);

            return true;
        }
    }
}
