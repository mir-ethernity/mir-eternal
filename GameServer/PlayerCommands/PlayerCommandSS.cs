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
