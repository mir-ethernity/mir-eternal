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
                    // 同步道具列表
                    var dir = BitConverter.GetBytes((ushort)GameDirection.左下);
                    SendPacket(
                        153,
                        0,
                        new byte[] { 
                            // ObjectID
                            45, 1, 0, 48, 
                            // NPC Template Id
                            137, 13, 0, 0,
                            // X
                            90, 107, 
                            // Y
                            208, 58, 
                            // terrain height
                            146, 4,
                            // direction
                            dir[0], dir[1], 
                            // flag interactive
                            1
                        }
                    );
                    // TODO: al abrir el cofre, recibimos el paquete 116, con el object id
                    // tenemos que lanzar el step 1
                    break;
                case 1:
                    // 开始操作道具
                    SendPacket(
                        154,
                        12,
                        new byte[] { 7, 0, 0, 0, 45, 1, 0, 48, 48, 0 }
                    );
                    break;
                case 2:
                    // EndOperationPropsPacket
                    SendPacket(
                        155,
                        11,
                        new byte[] { 7, 0, 0, 0, 45, 1, 0, 48, 0 }
                    );
                    break;
                case 3:
                    // ObjectDropItemsPacket
                    SendPacket(
                        150,
                        34,
                        new byte[] { 34, 0, 45, 1, 0, 48, 75, 117, 38, 80, 48, 107, 240, 58, 144, 4, 66, 96, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 7, 0, 0, 0 }
                    );
                    break;
                case 4:
                    // 同步道具次数
                    SendPacket(
                        70,
                        11,
                        new byte[] { 45, 1, 0, 48, 7, 0, 0, 0, 0 }
                    );
                    break;
                case 5:
                    // ObjectOutOfViewPacket
                    SendPacket(
                        62,
                        7,
                        new byte[] { 45, 1, 0, 48, 1 }
                    );
                    break;
                case 6:
                    Player.SendPacket(new StartOpenChestPacket
                    {
                        PlayerId = Player.ObjectId,
                        ObjectId = Player.ObjectId,
                        Duration = 32 // 2s
                    });
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
