using GameServer;
using GameServer.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XGameServer
{
    public class ConsoleLogger : IServerLogger
    {
        public void AddChatLog(string message)
        {
            Console.WriteLine($"[Chat] {message}");
        }

        public void AddCommandLog(string message)
        {
            Console.WriteLine($"[Command] {message}");
        }

        public void AddPacketLog(GamePacket packet, bool incoming)
        {
            if (packet.PacketInfo?.NoDebug ?? false) return;

            var data = packet.取字节(forceNoEncrypt: true);
            var message = string.Format(
                "[{0}]: {1} {2} ({3}) - {{{4}}}\r\n",
                DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                incoming ? "C->S" : "S->C",
                packet.PacketInfo.编号,
                packet.PacketType.Name,
                string.Join(", ", data.Select(x => x.ToString()).ToArray())
            );

            // Console.WriteLine($"[Packet] {message}");
        }

        public void AddSystemError(string message)
        {
            Console.Error.WriteLine($"[System] {message}");
        }

        public void AddSystemLog(string message)
        {
            Console.WriteLine($"[System] {message}");
        }
    }
}
