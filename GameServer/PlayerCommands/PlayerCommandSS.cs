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
                case 0:
                    // 同步Npcc数据 (Server)
                    SendPacket(
                    65,
                    16,
                    new byte[] { 123, 51, 0, 16, 147, 37, 0, 0, 1, 1, 15, 0, 0, 0 }
                    );

                    // 同步Npcc数据 (Server)
                    SendPacket(
                    65,
                    16,
                    new byte[] { 159, 37, 0, 16, 26, 26, 0, 0, 3, 1, 15, 39, 0, 0 }
                    );

                    // 同步Npcc数据 (Server)
                    SendPacket(
                    65,
                    16,
                    new byte[] { 121, 51, 0, 16, 147, 37, 0, 0, 1, 1, 15, 0, 0, 0 }
                    );

                    // 同步Npcc数据 (Server)
                    SendPacket(
                    65,
                    16,
                    new byte[] { 122, 51, 0, 16, 147, 37, 0, 0, 1, 1, 15, 0, 0, 0 }
                    );

                    // 同步Npcc数据 (Server)
                    SendPacket(
                    65,
                    16,
                    new byte[] { 125, 37, 0, 16, 6, 26, 0, 0, 3, 1, 15, 39, 0, 0 }
                    );

                    // 同步Npcc数据 (Server)
                    SendPacket(
                    65,
                    16,
                    new byte[] { 245, 39, 0, 16, 51, 3, 0, 0, 2, 10, 15, 0, 0, 0 }
                    );

                    // 同步Npcc数据 (Server)
                    SendPacket(
                    65,
                    16,
                    new byte[] { 134, 51, 0, 16, 142, 37, 0, 0, 1, 1, 15, 0, 0, 0 }
                    );

                    // 同步Npcc数据 (Server)
                    SendPacket(
                    65,
                    16,
                    new byte[] { 99, 51, 0, 16, 147, 37, 0, 0, 1, 1, 15, 0, 0, 0 }
                    );

                    // 同步Npcc数据 (Server)
                    SendPacket(
                    65,
                    16,
                    new byte[] { 126, 51, 0, 16, 147, 37, 0, 0, 1, 1, 15, 0, 0, 0 }
                    );

                    // 同步Npcc数据 (Server)
                    SendPacket(
                    65,
                    16,
                    new byte[] { 125, 51, 0, 16, 142, 37, 0, 0, 1, 1, 15, 0, 0, 0 }
                    );

                    // 同步Npcc数据 (Server)
                    SendPacket(
                    65,
                    16,
                    new byte[] { 124, 51, 0, 16, 147, 37, 0, 0, 1, 1, 15, 0, 0, 0 }
                    );

                    // 同步Npcc数据 (Server)
                    SendPacket(
                    65,
                    16,
                    new byte[] { 146, 37, 0, 16, 67, 26, 0, 0, 3, 99, 15, 39, 0, 0 }
                    );

                    // 同步Npcc数据 (Server)
                    SendPacket(
                    65,
                    16,
                    new byte[] { 136, 37, 0, 16, 23, 26, 0, 0, 3, 1, 15, 39, 0, 0 }
                    );

                    // 同步Npcc数据 (Server)
                    SendPacket(
                    65,
                    16,
                    new byte[] { 135, 37, 0, 16, 16, 26, 0, 0, 3, 1, 15, 39, 0, 0 }
                    );

                    // 同步Npcc数据 (Server)
                    SendPacket(
                    65,
                    16,
                    new byte[] { 120, 51, 0, 16, 147, 37, 0, 0, 1, 1, 15, 0, 0, 0 }
                    );

                    // 同步Npcc数据 (Server)
                    SendPacket(
                    65,
                    16,
                    new byte[] { 127, 37, 0, 16, 8, 26, 0, 0, 3, 1, 15, 39, 0, 0 }
                    );

                    // 同步Npcc数据 (Server)
                    SendPacket(
                    65,
                    16,
                    new byte[] { 126, 37, 0, 16, 7, 26, 0, 0, 3, 1, 15, 39, 0, 0 }
                    );
                    break;
                case 1:
                    SendPacket(
 60,
 20,
 new byte[] { 2, 99, 51, 0, 16, 5, 48, 109, 16, 60, 144, 4, 0, 24, 100, 0, 250, 255 }
 );
                    break;
                case 9:
                    // mark quest as completed and go next
                    SendPacket(
                        166,
                        6,
                        new byte[] { 161, 5, 0, 0 }
                    );
                    break;
                case 10:
                    SendPacket(
                        221,
                        10,
                        new byte[] { 25, 0, 0, 0, 2, 0, 0, 0 }
                    );
                    break;
                case 11:
                    SendPacket(
                        221,
                        10,
                        new byte[] { 78, 0, 0, 0, 9, 0, 0, 0 }
                    );
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
