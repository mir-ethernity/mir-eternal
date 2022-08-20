using System;
using System.Drawing;

namespace GameServer.Networking
{
    [PacketInfo(Source = PacketSource.Server, Id = 12, Length = 172, Description = "同步CharacterData(地图.坐标.职业.性别.等级...)")]
    public sealed class SyncCharacterPacket : GamePacket
    {
        [WrappingField(SubScript = 2, Length = 4)]
        public int ObjectId;

        [WrappingField(SubScript = 6, Length = 4)]
        public int CurrentMap;

        [WrappingField(SubScript = 10, Length = 4)]
        public int RouteId;

        [WrappingField(SubScript = 14, Length = 1)]
        public byte Race;

        [WrappingField(SubScript = 15, Length = 1)]
        public byte Gender;

        [WrappingField(SubScript = 16, Length = 1)]
        public byte CurrentLevel;

        [WrappingField(SubScript = 17, Length = 45)]
        public byte[] Unknown1 = new byte[45];

        [WrappingField(SubScript = 62, Length = 4)]
        public Point CurrentPosition;

        [WrappingField(SubScript = 66, Length = 2)]
        public ushort CurrentAltitude;

        [WrappingField(SubScript = 68, Length = 2)]
        public ushort Direction;

        [WrappingField(SubScript = 70, Length = 2)]
        public ushort Distance = 1;

        [WrappingField(SubScript = 72, Length = 8)]
        public ulong RequiredExp;

        [WrappingField(SubScript = 80, Length = 4)]
        public ulong ExpCap = ulong.MaxValue;

        [WrappingField(SubScript = 88, Length = 4)]
        public int DoubleExp;

        [WrappingField(SubScript = 92, Length = 4)]
        public int Unknown3 = 0;

        [WrappingField(SubScript = 96, Length = 4)]
        public int PKLevel;

        [WrappingField(SubScript = 100, Length = 1)]
        public byte AttackMode;

        [WrappingField(SubScript = 101, Length = 16)]
        public byte[] Unknown4 = new byte[16];

        [WrappingField(SubScript = 117, Length = 4)]
        public int CurrentTime;

        [WrappingField(SubScript = 121, Length = 14)]
        public byte[] Unknown5 = new byte[14];

        [WrappingField(SubScript = 135, Length = 2)]
        public ushort MaxLevel;

        [WrappingField(SubScript = 137, Length = 8)]
        public byte[] Unknown6 = new byte[8];

        [WrappingField(SubScript = 145, Length = 8)]
        public ulong CurrentExp;

        [WrappingField(SubScript = 153, Length = 1)]
        public bool BrownName = false;

        [WrappingField(SubScript = 154, Length = 16)]
        public byte[] Unknown7 = new byte[16];

        [WrappingField(SubScript = 170, Length = 2)]
        public ushort EquipRepairDto;
    }
}
