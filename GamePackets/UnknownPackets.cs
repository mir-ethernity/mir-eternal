using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Networking
{
    [PacketInfo(来源 = PacketSource.Client, 编号 = 265, 长度 = 142, 注释 = "UnknownC1")]
    public class UnknownC4 : GamePacket
    {
    }


    [PacketInfo(来源 = PacketSource.Client, 编号 = 642, 长度 = 4, 注释 = "UnknownC1")]
    public class UnknownC1 : GamePacket
    {
    }

    [PacketInfo(来源 = PacketSource.Client, 编号 = 644, 长度 = 0, 注释 = "UnknownC1")]
    public class UnknownC2 : GamePacket
    {
    }

    [PacketInfo(来源 = PacketSource.Client, 编号 = 155, 长度 = 6, 注释 = "UnknownC1")]
    public class UnknownC3 : GamePacket
    {
        [WrappingField(SubScript = 2, Length = 2)]
        public ushort U1;
        [WrappingField(SubScript = 4, Length = 2)]
        public ushort U2;
    }

    [PacketInfo(来源 = PacketSource.Server, 编号 = 691, 长度 = 16, 注释 = "UnknownS1")]
    public class UnknownS1 : GamePacket
    {
        [WrappingField(SubScript = 2, Length = 2)]
        public ushort U1;
        [WrappingField(SubScript = 4, Length = 2)]
        public ushort U2;
        [WrappingField(SubScript = 6, Length = 2)]
        public ushort U3;
        [WrappingField(SubScript = 8, Length = 2)]
        public ushort U4;
        [WrappingField(SubScript = 10, Length = 2)]
        public ushort U5;
        [WrappingField(SubScript = 12, Length = 2)]
        public ushort U6;
        [WrappingField(SubScript = 14, Length = 2)]
        public ushort U7;
    }

    [PacketInfo(来源 = PacketSource.Server, 编号 = 692, 长度 = 6, 注释 = "UnknownS2")]
    public class UnknownS2 : GamePacket
    {
    }

    [PacketInfo(来源 = PacketSource.Server, 编号 = 529, 长度 = 39, 注释 = "UnknownS3")]
    public class UnknownS3 : GamePacket
    {
        [WrappingField(SubScript = 2, Length = 12)]
        public byte[] U1 = new byte[] { 0, 26, 53, 0, 0, 0, 0, 0, 1, 0, 0, 1 };
        [WrappingField(SubScript = 14, Length = 4)]
        public int MapId;
        [WrappingField(SubScript = 18, Length = 4)]
        public int PlayerId;
        [WrappingField(SubScript = 22, Length = 17)]
        public byte[] U2 = new byte[] { 0, 0, 0, 0, 181, 0, 0, 0, 72, 0, 0, 0, 225, 4, 0, 0, 176 };
    }
}
