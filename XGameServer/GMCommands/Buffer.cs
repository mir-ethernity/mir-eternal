using GameServer.Data;
using GameServer.Networking;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.GMCommands
{
    public class Buffer : GMCommand
    {
        public override ExecutionWay ExecutionWay => ExecutionWay.优先后台执行;

        [Field(0, Position = 0)]
        public string CharName;

        [Field(0, Position = 1)]
        public int Type;

        [Field(0, Position = 2)]
        public int Length;

        [Field(0, Position = 3)]
        public string Hex;

        public override void Execute()
        {
            if (!GameDataGateway.CharacterDataTable.Keyword.TryGetValue(this.CharName, out GameData gameData))
                return;

            var characterData = gameData as CharacterData;

            if (characterData == null)
                return;

            if (characterData.ActiveConnection == null)
                return;

            var data = Enumerable.Range(0, Hex.Length)
                     .Where(x => x % 2 == 0)
                     .Select(x => Convert.ToByte(Hex.Substring(x, 2), 16))
                     .ToArray();

            var buffer = new byte[2 + (Length == 0 ? 2 : 0) + data.Length];

            using var ms = new MemoryStream(buffer);
            using var bw = new BinaryWriter(ms);

            bw.Write((ushort)Type);
            if (Length == 0) bw.Write((ushort)data.Length);
            bw.Write(data);

            for (var i = 4; i < buffer.Length; i++)
                buffer[i] ^= GamePacket.EncryptionKey;

            characterData.ActiveConnection.Connection.Client.Send(buffer);
        }
    }
}
