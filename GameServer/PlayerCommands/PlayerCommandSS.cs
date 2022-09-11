using GamePackets.Server;
using GameServer.Data;
using GameServer.Networking;
using GameServer.Templates;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.PlayerCommands
{
    public class PlayerCommandSS : PlayerCommand
    {
        [Field(Position = 0)]
        public int Step;

        public override void Execute()
        {
            switch (Step)
            {
                case 0: // on start talk with npc viejo
                    SendPacket(222, 10, new byte[] { 5, 0, 0, 0, 3, 0, 0, 0 });
                    break;
                case 1: // a type of reward??
                    SendPacket(178, 7, new byte[] { 30, 11, 0, 0, 0 });
                    break;
                case 2: // on complete first quest
                    SendPacket(221, 10, new byte[] { 25, 0, 0, 0, 1, 0, 0, 0 });
                    SendPacket(221, 10, new byte[] { 78, 0, 0, 0, 1, 0, 0, 0 });
                    break;
                case 3: // anything related with rewards?
                    SendPacket(222, 10, new byte[] { 11, 0, 0, 0, 10, 0, 0, 0 });
                    break;
                case 4:
                    SendPacket(187, 13, new byte[] { 6, 0, 0, 165, 5, 0, 0, 1, 0, 0, 0 });
                    break;
                case 99:
                    SendPacket(35, 0, new byte[] { 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 14, 6, 16, 66, 0, 27, 118, 28, 99, 227, 195, 91, 5, 0, 0, 88, 27, 0, 0, 88, 27, 0, 0, 10, 0, 1, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 14, 12, 16, 66, 0, 184, 110, 28, 99, 225, 35, 93, 5, 0, 1, 121, 19, 0, 0, 136, 19, 0, 0, 10, 0, 1, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 14, 0, 16, 66, 0, 115, 113, 28, 99, 129, 168, 244, 5, 0, 8, 212, 27, 0, 0, 116, 32, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 14, 0, 16, 66, 0, 244, 118, 28, 99, 226, 150, 42, 4, 0, 9, 13, 39, 0, 0, 16, 39, 0, 0, 10, 0, 1, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 14, 13, 16, 66, 0, 78, 122, 28, 99, 227, 150, 42, 4, 0, 11, 16, 39, 0, 0, 16, 39, 0, 0, 10, 0, 1, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 14, 1, 16, 66, 0, 154, 112, 28, 99, 161, 246, 244, 5, 0, 12, 66, 16, 0, 0, 144, 16, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 });
                    break;
                default:
                    break;
            }
        }

        private void SendPacket(ushort type, int length, byte[] data)
        {
            var sb = new StringBuilder();

            for (var i = 0; i < data.Length; i++)
            {
                sb.AppendLine(data[i].ToString());
            }

            var output = sb.ToString();

            var buffer = new byte[2 + (length == 0 ? 2 : 0) + data.Length];

            using var ms = new MemoryStream(buffer);
            using var bw = new BinaryWriter(ms);

            bw.Write((ushort)type);
            if (length == 0) bw.Write((ushort)buffer.Length);
            bw.Write(data);

            for (var i = 4; i < buffer.Length; i++)
                buffer[i] ^= GamePacket.EncryptionKey;

            Player.ActiveConnection.Connection.Client.Send(buffer);
        }
    }
}
