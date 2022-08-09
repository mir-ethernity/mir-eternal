using GameServer.Data;
using GameServer.Networking;
using GameServer.Templates;
using System.Text;

namespace GameServer
{
    public static class SEnvir
    {
        public static IServerLogger? Logger { get; set; }

        public static async Task Start()
        {
            AddSystemLog("Loading system data...");
            await SystemDataService.LoadData();
            AddSystemLog("System data has been loaded succesful");
            AddSystemLog("Loading client data...");
            await GameDataGateway.加载数据();
            AddSystemLog("Client data has been loaded successful");
            MainProcess.Start();
        }

        public static void AddCommandLog(string message)
        {
            Logger?.AddCommandLog(message);
        }

        public static void AddSystemError(string message)
        {
            Logger?.AddSystemError(message);
        }

        public static void AddSystemLog(string message)
        {
            Logger?.AddSystemLog(message);
        }

        public static void AddPacketLog(GamePacket packet, bool incoming)
        {
            Logger?.AddPacketLog(packet, incoming);
        }

        public static void AddChatLog(string preffix, byte[] text)
        {
            var msg = string.Format("[{0:F}]: {1}", DateTime.Now, preffix + Encoding.UTF8.GetString(text).Trim(new char[1])) + "\r\n";
            Logger?.AddChatLog(msg);
        }

    }
}