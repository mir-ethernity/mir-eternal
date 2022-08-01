using System;
using System.Drawing;

namespace GameServer.Networking
{
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 12, 长度 = 172, 注释 = "同步CharacterData(地图.坐标.职业.性别.等级...)")]
	public sealed class RawSyncCharacterPacket : GamePacket
	{
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int ObjectId;

		[WrappingFieldAttribute(SubScript = 6, Length = 166)]
		public byte[] Data;
    }


	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 12, 长度 = 172, 注释 = "同步CharacterData(地图.坐标.职业.性别.等级...)")]
	public sealed class SyncCharacterPacket : GamePacket
	{
		
		public SyncCharacterPacket()
		{
			
			this.经验上限 = 2000000000;
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int ObjectId;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int CurrentMap;

		
		[WrappingFieldAttribute(SubScript = 10, Length = 4)]
		public int RouteId;

		
		[WrappingFieldAttribute(SubScript = 14, Length = 1)]
		public byte Race;

		
		[WrappingFieldAttribute(SubScript = 15, Length = 1)]
		public byte Gender;

		
		[WrappingFieldAttribute(SubScript = 16, Length = 1)]
		public byte CurrentLevel;

		
		[WrappingFieldAttribute(SubScript = 62, Length = 4)]
		public Point CurrentPosition;

		
		[WrappingFieldAttribute(SubScript = 66, Length = 2)]
		public ushort CurrentAltitude;

		
		[WrappingFieldAttribute(SubScript = 68, Length = 2)]
		public ushort Direction;

		
		[WrappingFieldAttribute(SubScript = 71, Length = 4)]
		public int RequiredExp;

		
		[WrappingFieldAttribute(SubScript = 83, Length = 4)]
		public int 经验上限;

		
		[WrappingFieldAttribute(SubScript = 87, Length = 4)]
		public int 双倍经验;

		
		[WrappingFieldAttribute(SubScript = 95, Length = 4)]
		public int PKLevel;

		
		[WrappingFieldAttribute(SubScript = 99, Length = 1)]
		public byte AttackMode;

		
		[WrappingFieldAttribute(SubScript = 116, Length = 4)]
		public int CurrentTime;

		
		[WrappingFieldAttribute(SubScript = 134, Length = 2)]
		public ushort MaxLevel;

		
		[WrappingFieldAttribute(SubScript = 144, Length = 4)]
		public int CurrentExp;

		
		[WrappingFieldAttribute(SubScript = 169, Length = 2)]
		public ushort EquipRepairDto;
	}
}
