using System;
using System.Drawing;

namespace GameServer.Networking
{
	[PacketInfo(来源 = PacketSource.Server, 编号 = 12, 长度 = 172, 注释 = "同步CharacterData(地图.坐标.职业.性别.等级...)")]
	public sealed class RawSyncCharacterPacket: GamePacket
    {

    }

	[PacketInfo(来源 = PacketSource.Server, 编号 = 12, 长度 = 172, 注释 = "同步CharacterData(地图.坐标.职业.性别.等级...)")]
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


		[WrappingField(SubScript = 62, Length = 4)]
		public Point CurrentPosition;


		[WrappingField(SubScript = 66, Length = 2)]
		public ushort CurrentAltitude;


		[WrappingField(SubScript = 68, Length = 2)]
		public ushort Direction;

		[WrappingField(SubScript = 70, Length = 2)]
		public ushort Distance = 1;

		[WrappingField(SubScript = 72, Length = 4)]
		public int RequiredExp;


		[WrappingField(SubScript = 84, Length = 4)]
		public uint ExpCap = 0x7FFFFFFF;


		[WrappingField(SubScript = 88, Length = 4)]
		public int DoubleExp;

		[WrappingField(SubScript = 96, Length = 4)]
		public int PKLevel;

		[WrappingField(SubScript = 100, Length = 1)]
		public byte AttackMode;

		[WrappingField(SubScript = 117, Length = 4)]
		public int CurrentTime;

		[WrappingField(SubScript = 135, Length = 2)]
		public ushort MaxLevel;

		[WrappingField(SubScript = 145, Length = 4)]
		public int CurrentExp;

		[WrappingField(SubScript = 170, Length = 2)]
		public ushort EquipRepairDto;

		#region Unknown fields with values
		// [WrappingField(SubScript = 137, Length = 2)]
		//public ushort U1 = 1;
		//[WrappingField(SubScript = 139, Length = 2)]
		//public ushort U2 = 1;
		//[WrappingField(SubScript = 132, Length = 1)]
		//public byte U3 = 37;
		//[WrappingField(SubScript = 133, Length = 1)]
		//public byte U4 = 207;
		//[WrappingField(SubScript = 58, Length = 4)]
		//public int U6 = 56;
		//[WrappingField(SubScript = 38, Length = 1)]
		//public byte U7 = 9;
		//[WrappingField(SubScript = 34, Length = 4)]
		//public int U8 = 4;
		//[WrappingField(SubScript = 17, Length = 4)]
		//public int U9 = 2;
		//[WrappingField(SubScript = 22, Length = 1)]
		//public byte U10 = 255;
		//[WrappingField(SubScript = 134, Length = 1)]
		//public byte U11 = 86;
		//[WrappingField(SubScript = 43, Length = 1)]
		//public byte U13 = 9;
		#endregion
	}
}
