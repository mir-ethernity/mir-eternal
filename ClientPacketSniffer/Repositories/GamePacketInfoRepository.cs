using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientPacketSniffer.Repositories
{
    public class GamePacketInfoRepository
    {
        public static GamePacketInfoRepository Instance { get; } = new GamePacketInfoRepository();
       
        public Dictionary<ushort, GamePacketInfo> ClientPackets { get; private set; }
        public Dictionary<ushort, GamePacketInfo> ServerPackets { get; private set; }


        private GamePacketInfoRepository()
        {
            var clientPackets = ReadGamePacketInfo(0, File.ReadAllText("ClientPackRule.txt", Encoding.UTF8));
            var serverPackets = ReadGamePacketInfo(1, File.ReadAllText("ServerPackRule.txt", Encoding.UTF8));

            ClientPackets = clientPackets.ToDictionary(x => x.Id, y => y);
            ServerPackets = serverPackets.ToDictionary(x => x.Id, y => y);
        }

        private GamePacketInfo[] ReadGamePacketInfo(byte source, string content)
        {
            var output = new List<GamePacketInfo>();
            var packets = content.Trim().Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var packet in packets)
            {
                var data = packet.Split(new char[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (data[0].StartsWith('#')) continue;

                output.Add(new GamePacketInfo
                {
                    Name = data[0],
                    Source = source,
                    Id = ushort.Parse(data[1]),
                    Length = ushort.Parse(data[2])
                });
            }
            return output.ToArray();
        }
    }
}
