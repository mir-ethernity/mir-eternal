using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Networking
{
    [PacketInfo(Source = PacketSource.Client, Id = 642, Length = 4, Description = "UnknownC1")]
    public class UnknownC642 : GamePacket
    {
    }

    [PacketInfo(Source = PacketSource.Client, Id = 644, Length = 0, Description = "UnknownC1")]
    public class UnknownC644 : GamePacket
    {
    }

    [PacketInfo(Source = PacketSource.Client, Id = 155, Length = 6, Description = "UnknownC1")]
    public class UnknownC155 : GamePacket
    {
        [WrappingField(SubScript = 2, Length = 4)]
        public int U1;
    }

    [PacketInfo(Source = PacketSource.Client, Id = 264, Length = 22, Description = "UnknownC4")]
    public class UnknownC264 : GamePacket
    {
    }

    [PacketInfo(Source = PacketSource.Client, Id = 265, Length = 11, Description = "UnknownC4")]
    public class UnknownC265 : GamePacket
    {
    }

    [PacketInfo(Source = PacketSource.Client, Id = 266, Length = 11, Description = "Unknown266")]
    public class UnknownC266 : GamePacket
    {
    }

    [PacketInfo(Source = PacketSource.Client, Id = 255, Length = 6, Description = "UnknownC255")]
    public class UnknownC255 : GamePacket
    {
        [WrappingField(SubScript = 2, Length = 4)]
        public int U1;
    }

    [PacketInfo(Source = PacketSource.Client, Id = 271, Length = 2, Description = "Received on player connects (ver. 1.0.3.68 / 185578)")]
    public class PlayerEnterScenePacket : GamePacket
    {
    }

    [PacketInfo(Source = PacketSource.Server, Id = 691, Length = 16, Description = "UnknownS1")]
    public class UnknownS691 : GamePacket
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

    [PacketInfo(Source = PacketSource.Server, Id = 692, Length = 16, Description = "UnknownS2")]
    public class UnknownS692 : GamePacket
    {
    }

    [PacketInfo(Source = PacketSource.Server, Id = 529, Length = 39, Description = "UnknownS3")]
    public class UnknownS529 : GamePacket
    {
        [WrappingField(SubScript = 2, Length = 37)]
        public byte[] Data = new byte[37];
    }

    [PacketInfo(Source = PacketSource.Server, Id = 222, Length = 10, Description = "UnknownS3")]
    public class UnknownS222 : GamePacket
    {
        [WrappingField(SubScript = 2, Length = 4)]
        public int U1;
        [WrappingField(SubScript = 6, Length = 4)]
        public int U2;
    }

    [PacketInfo(Source = PacketSource.Server, Id = 218, Length = 10, Description = "UnknownS3")]
    public class UnknownS218 : GamePacket
    {
        [WrappingField(SubScript = 2, Length = 4)]
        public int U1;
        [WrappingField(SubScript = 6, Length = 4)]
        public int U2;
    }

    [PacketInfo(Source = PacketSource.Client, Id = 272, Length = 2, Description = "UnknownC272")]
    public class UnknownC272 : GamePacket
    {
    }

    [PacketInfo(Source = PacketSource.Client, Id = 252, Length = 0, Description = "UnknownC252")]
    public class UnknownC252 : GamePacket
    {
        [WrappingField(SubScript = 4, Length = 0)]
        public int U1;
    }

    [PacketInfo(Source = PacketSource.Client, Id = 267, Length = 142, Description = "UnknownC267")]
    public class UnknownC267 : GamePacket
    {
        [WrappingField(SubScript = 2, Length = 140)]
        public int U1;
    }
}
